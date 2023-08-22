using System.Collections.ObjectModel;
using MoreLinq;

namespace VectorRasterDemo
{

    
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
            Draw();
            Draw();
        }

        private static void Draw()
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