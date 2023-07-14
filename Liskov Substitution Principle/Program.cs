using static System.Console;

namespace Liskov_Substitution_Principle
{
    internal class Program
    {

        public static int Area(Rectangle r) => r.Width * r.Height;

        static void Main(string[] args)
        {
            var rectangle = new Rectangle(10, 30);
            WriteLine($"{rectangle} has area {Area(rectangle)}");

            Rectangle square = new Square();
            square.Width = 10;
            WriteLine($"{square} has area {Area(square)}");

        }
    }
}