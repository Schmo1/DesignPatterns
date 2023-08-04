
namespace FactoryMethod
{
    public class Point
    {
        public double x, y;

        // factory method
        public static Point NewCaresianPoint(double x, double y)
        {
            return new Point(x, y);
        }

        public static Point NewPolarPoint(double rho, double theta)
        {
            return new Point(rho * Math.Cos(theta), rho * Math.Sin(theta));
        }

        private Point(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public override string? ToString()
        {
            return $"{nameof(y)}: {y}, {nameof(x)}: {x}";
        }
    }
}
