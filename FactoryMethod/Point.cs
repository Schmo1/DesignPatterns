using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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


        // factory method
        public static Point NewCartesianPoint(double x, double y)
        {
            return new Point(x, y);
        }
        public static Point NewPolanPoint(double rho, double theta)
        {
            return new Point(rho*Math.Cos(theta), rho*Math.Sin(theta));
        }
    }
}
