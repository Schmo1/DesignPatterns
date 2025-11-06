using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Autofac;

namespace DeclarativeEventSubscriptions;

public interface IEvent
{
}

public interface ISend<TEvent>
    where TEvent : IEvent
{
    event EventHandler<TEvent> Sender;
}

public interface IHandle<TEvent>
    where TEvent : IEvent
{
    void Handle(object? sender, TEvent args);
}

public class ButtonPressedEvent : IEvent
{
    public int NumberOfClicks;

}

public class Button : ISend<ButtonPressedEvent>
{
    public event EventHandler<ButtonPressedEvent> Sender = delegate { };
    public void Fire(int numberOfClicks)
    {
        Sender?.Invoke(this, new ButtonPressedEvent { NumberOfClicks = numberOfClicks });
    }
}

public class Logging : IHandle<ButtonPressedEvent>
{
    public void Handle(object? sender, ButtonPressedEvent args)
    {
        Console.WriteLine($"Button pressed {args.NumberOfClicks} times");
    }
}

internal class Program
{
    static void Main(string[] args)
    {
        var cb = new ContainerBuilder();
        var ass = Assembly.GetExecutingAssembly();

        cb.RegisterAssemblyTypes(ass)
            .AsClosedTypesOf(typeof(ISend<>))
            .SingleInstance();

        cb.RegisterAssemblyTypes(ass)
            .Where(t => 
            t.GetInterfaces()
            .Any(i =>
            i.IsGenericType &&
            i.GetGenericTypeDefinition() == typeof(IHandle<>)))
            .OnActivated(act =>
            {
                var instanceType = act.Instance.GetType();
                var interfaces = instanceType.GetInterfaces();
                foreach (Type i in interfaces)
                {
                    if (i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IHandle<>))
                    {
                        Type arg0 = i.GetGenericArguments()[0];
                        //arg0 ist TEvent z.b.


                        Type senderType = typeof(ISend<>).MakeGenericType(arg0);

                        Type allSenderTypes = typeof(IEnumerable<>).MakeGenericType(senderType);

                        var allServices = act.Context.Resolve(allSenderTypes);

                        foreach (var service in (IEnumerable)allServices)
                        {
                            EventInfo? eventInfo = service.GetType().GetEvent("Sender");
                            MethodInfo? handleMethod = instanceType.GetMethod("Handle");
                            Delegate handler = Delegate.CreateDelegate(eventInfo.EventHandlerType, null, handleMethod);
                            eventInfo.AddEventHandler(service, handler);
                        }
                    }
                }
            }).SingleInstance()
            .AsSelf();

        var container = cb.Build();

        var button = container.Resolve<Button>();
        var logging = container.Resolve<Logging>();

        button.Fire(1);
        button.Fire(2);
    } 

}



