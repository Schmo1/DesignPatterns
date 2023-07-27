namespace FactoryMethod
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Point point = Point.NewCartesianPoint(0, 0);
            Point pointPolan = Point.NewPolanPoint(1.0, Math.PI / 2);

        }
    }
}