namespace FactoryMethod
{

    internal class Program
    {
        static void Main(string[] args)
        {
           var point = Point.NewPolarPoint(1.0,Math.PI/2);

            Console.WriteLine(point);
        }
    }
}