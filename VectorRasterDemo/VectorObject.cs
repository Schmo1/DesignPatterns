using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace VectorRasterDemo
{
    public class Point
    {
        public int X, Y;
        public Point(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        protected bool Equals(Point other)
        {
            return X == other.X && Y == other.Y;
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if(ReferenceEquals(this, obj)) return true;
            if(obj.GetType() != this.GetType()) return false;
            return Equals((Point)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (X * 397) ^ Y;
            }
        }


    }

    public class Line
    {
        public Point Start, End;
        public Line(Point start, Point end)
        {
            this.Start = start;
            this.End = end;

        }

        public override bool Equals(object? obj)
        {
            return obj is Line line &&
                   EqualityComparer<Point>.Default.Equals(Start, line.Start) &&
                   EqualityComparer<Point>.Default.Equals(End, line.End);
        }

        public override int GetHashCode()
        {
            return ((Start != null ? Start.GetHashCode() : 0) * 397) ^ 
                    (End != null ? End.GetHashCode() : 0);
        }
    }

    public class VectorObject : Collection<Line>
    {

    }

    public class VectorRectangle : VectorObject
    {
        public VectorRectangle(int x, int y, int width, int height)
        {
            Add(new Line(new Point(x, y), new Point(x + width, y)));
            Add(new Line(new Point(x + width, y), new Point(x + width, y + height)));
            Add(new Line(new Point(x, y), new Point(x, y + height)));
            Add(new Line(new Point(x, y + height), new Point(x + width, y + height)));
        }
    }

    public class LineToPointAdapter : IEnumerable<Point>
    {
        private static int count;
        static Dictionary<int, List<Point>> chache = new();
        public LineToPointAdapter(Line line)
        {
            var has = line.GetHashCode();
            if (chache.ContainsKey(has)) return;

            Console.WriteLine($"{++count}: Generating points for line [{line.Start.X}, {line.Start.Y}]-[{line.End.X}, {line.End.Y}]");

            var points = new List<Point>();

            int left = Math.Min(line.Start.X, line.End.X);
            int right = Math.Max(line.Start.X, line.End.X);
            int top = Math.Min(line.Start.Y, line.End.Y);
            int bottom = Math.Max(line.Start.Y, line.End.Y);
            int dx = right - left;
            int dy = line.End.Y - line.Start.Y;

            if (dx == 0)
            {
                for (int y = top; y <= bottom; ++y)
                {
                    points.Add(new Point(left, y));
                }
            }
            else if (dy == 0)
            {
                for (int x = left; x <= right; ++x)
                {
                    points.Add(new Point(x, top));
                }
            }
            
            chache[has] = points;
        }

        public IEnumerator<Point> GetEnumerator()
        {
            return chache.Values.SelectMany(x => x).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
