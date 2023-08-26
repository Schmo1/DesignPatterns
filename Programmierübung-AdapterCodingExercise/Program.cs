namespace Programmierübung_AdapterCodingExercise
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }

        public interface IRectangle
        {
            int Width { get; }
            int Height { get; }
        }

        public class Square
        {
            public int Side;
        }

        public class SquareToRectangleAdapter : IRectangle
        {
            private int width;
            private int height;
            public SquareToRectangleAdapter(Square square)
            {
                width = height = square.Side;
            }

            public int Width => width;

            public int Height => height;

        }
    }
}