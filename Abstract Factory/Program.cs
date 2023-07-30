using static System.Console;

namespace Abstract_Factory
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            var machine = new HotDrinkMachine();
            var drink = machine.MakeDrink(HotDrinkMachine.AvailableDrink.Tea, 100);
            drink.Consume();


            WriteLine(typeof(HotDrinkMachine));
            WriteLine(Type.GetType("Abstract_Factory.HotDrinkMachine"));
            
        }
    }
}