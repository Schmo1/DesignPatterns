namespace FactoryMethod
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            Point point = Point.Factory.NewCartesianPoint(0, 0);
            Point pointPolan = Point.Factory.NewPolanPoint(1.0, Math.PI / 2);

            

        }
    }
}