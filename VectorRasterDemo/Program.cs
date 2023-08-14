﻿using System.Collections.ObjectModel;
using MoreLinq;

namespace VectorRasterDemo
{

    public class Point
    {
        public int X,Y;
        public Point(int x, int y)
        {
            this.X = x;
            this.Y = y;                 
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

    public class LineToPointAdapter :Collection<Point>
    {
        private static int count;
        public LineToPointAdapter(Line line)
        {
            Console.WriteLine($"{++count}: Generating points for line [{line.Start.X}, {line.Start.Y}]-[{line.End.X}, {line.End.Y}]");

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
                    Add(new Point(left, y));
                }
            }
            else if (dy == 0)
            {
                for (int x = left; x <= right; ++x)
                {
                    Add(new Point(x, top));
                }
            }
        }
    }


    internal class Program
    {
        private static readonly List<VectorObject> vectorObjects = new List<VectorObject>()
        {
            new VectorRectangle(0,1,10,20),
            new VectorRectangle(4,3,6,6),
        };

        public static void DrawPoint(Point point)
        {
            Console.Write(".");
        }

        static void Main(string[] args)
        {
            foreach (var vo in vectorObjects)
            {
                foreach (var line in vo)
                {
                    var adapter = new LineToPointAdapter(line);
                    adapter.ForEach(DrawPoint);
                }
            }
        }
    }
}