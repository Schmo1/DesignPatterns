﻿
using Autofac;
using Autofac.Features.Metadata;


namespace AdapterDependencyInjection
{
    public interface ICommand
    {
        void Execute();
    }

    class SaveCommand : ICommand
    {
        public void Execute()
        {
            Console.WriteLine("Saving a file");
        }
    }

    class OpenCommand : ICommand
    {
        public void Execute()
        {
            Console.WriteLine("Open a file");
        }
    }

    public class Button
    {
        private ICommand command;
        private string name;

        public Button(ICommand command, string name)
        {
            if (command == null)
            {
                throw new ArgumentNullException(paramName: nameof(command));
            }
            this.command = command;
            this.name = name;
        }

        public void Click()
        {
            command.Execute();
        }

        public void PrintMe()
        {
            Console.WriteLine($"I am a button called {name}");
        }
    }

    public class Editor
    {
        private IEnumerable<Button> buttons;

        public IEnumerable<Button> Buttons => buttons;

        public Editor(IEnumerable<Button> buttons)
        {
            if (buttons == null)
            {
                throw new ArgumentNullException(paramName: nameof(buttons));
            }
            this.buttons = buttons;
        }


        public void ClickAll()
        {
            foreach (var button in buttons)
            {
                button.Click();
            }
        }
    
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            var b = new ContainerBuilder();
            b.RegisterType<SaveCommand>().As<ICommand>()
                .WithMetadata("Name","Save");
            b.RegisterType<OpenCommand>().As<ICommand>()
                .WithMetadata("Name", "Open"); ;
            //b.RegisterType<Button>();
            //b.RegisterAdapter<ICommand, Button>(cmd => new Button(cmd));
            b.RegisterAdapter<Meta<ICommand>, Button>(cmd =>
                new Button(cmd.Value, (string)cmd.Metadata["Name"]));
            b.RegisterType<Editor>();

            using (var c  = b.Build())
            {
                var editor = c.Resolve<Editor>();
                //editor.ClickAll();

                foreach (var btn in editor.Buttons)
                {
                    btn.PrintMe();
                }
            }
        }
 
    }


}