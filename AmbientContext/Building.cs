

using System.Text;

namespace AmbientContext
{
    public sealed class BuildingContext : IDisposable
    {
        public int WallHeight;
        private static Stack<BuildingContext> stack = new();

        static BuildingContext()
        {
            stack.Push(new BuildingContext(0));
        }

        public BuildingContext(int wallHeight)
        {
            WallHeight = wallHeight;
            stack.Push(this);
        }

        public static BuildingContext Current => stack.Peek();

        public void Dispose()
        {
            if (stack.Count > 1)
            {
                stack.Pop();
            }
        }
    }
    public class Building
    {
        public List<Wall> Walls = new List<Wall>();

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (Wall wall in Walls)
            {
                sb.AppendLine(wall.ToString());
            }
            return sb.ToString();
        }
    }

    public class Wall
    {
        public Point Start, End;
        public int Height;

        public Wall(Point start, Point end)
        {
            Start = start;
            End = end;
            Height = BuildingContext.Current.WallHeight;
        }



        public override string ToString()
        {
            return $"{nameof(Start)}: {Start}, {nameof(End)}: {End}, {nameof(Height)}: {Height}";
        }
        


    }

    public struct Point
    {
        private int x, y;

        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public override string ToString()
        {
            return $"{nameof(x)}: {x}, {nameof(y)}: {y}";
        }

    }
}
