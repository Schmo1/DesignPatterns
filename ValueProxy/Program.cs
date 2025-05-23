using System.Diagnostics;

namespace ValueProxy
{
    public struct Percentage
    {
        [DebuggerDisplay("{value*100.0f}%")]
        private readonly float value;

        internal Percentage(float value)
        {
            this.value = value;
        }

        public static float operator *(float f, Percentage p)
        {
            return f * p.value;
        }

        public static Percentage operator +(Percentage p1, Percentage p2)
        {
            return new Percentage(p1.value + p2.value);
        }

        public override string ToString()
        {
            return $"{value * 100}%";
        }


    }

    public static class PercentageExtensions
    {
        public static Percentage Percent(this float value)
        {
            return new Percentage(value / 100.0f);
        }

        public static Percentage Percent(this int value)
        {
            return new Percentage(value / 100.0f);
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(10f * 5.Percent());
            Console.WriteLine(2.Percent() + 5.Percent());
        }
    }
}
