using Autofac;
using JetBrains.Annotations;
using MediatR;
using System.Threading.Tasks;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MediatR_Example
{

    // ping 

    public class PingCommand : IRequest<PongResponse>
    {

    }

    public class PongResponse
    {
        public DateTime Timestamp;

        public PongResponse(DateTime time)
        {
            Timestamp = time;
        }
    }

    [UsedImplicitly]
    public class PingCommandHandler : IRequestHandler<PingCommand, PongResponse>
    {
        public Task<PongResponse> Handle(PingCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult(new PongResponse(DateTime.UtcNow));
        }
    }

    internal class Program
    {
        static async Task Main(string[] args)
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<Mediator>()
                .As<IMediator>()
                .InstancePerLifetimeScope();

            //builder.Register<ServiceFactory>(context =>
            //{
            //    var c = context.Resolve<IComponentContext>();
            //    return t => c.Resolve(t);
            //});

            builder.RegisterAssemblyTypes(typeof(Program).Assembly)
                .AsImplementedInterfaces();

            var container = builder.Build();
            var mediator = container.Resolve<IMediator>();
            var response = await mediator.Send(new PingCommand());

            Console.WriteLine($"We got a response at {response.Timestamp}");
        }
    }
}
