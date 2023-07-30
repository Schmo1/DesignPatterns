namespace FactoryMethod
{
    public class Point
    {
        private double X, Y;
        private Point(double x,double y)
        {
            this.X = x;
            this.Y = y;
        }

        public override string ToString()
        {
            return $"{nameof(X)} ; {X}, {nameof(Y)} ; {Y}";
        }

        public static Point Origin = new(0,0);

        public static class Factory
        {
            // factory method
            public static Point NewCartesianPoint(double x, double y)
            {
                return new Point(x, y);
            }
            public static Point NewPolanPoint(double rho, double theta)
            {
                return new Point(rho * Math.Cos(theta), rho * Math.Sin(theta));
            }
        }

    }

}
