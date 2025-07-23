using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace CompositeProxy;

public class Program
{
    public class Creature
    {
        public byte age;
        public int x, y;
    }

    public class Creatures
    {
        private readonly int size;
        private byte[] age;
        private int[] x, y;

        public Creatures(int size)
        {
            this.size = size;
            age = new byte[size];
            x = new int[size];
            y = new int[size];
        }

        public struct CreatureProxy
        {
            private readonly Creatures creatures;
            private readonly int index;
            public CreatureProxy(Creatures creatures, int index)
            {
                this.creatures = creatures;
                this.index = index;
            }

            public ref byte Age => ref creatures.age[index];
            public ref int X => ref creatures.x[index];
            public ref int Y => ref creatures.y[index];

        }
        public IEnumerator<CreatureProxy> GetEnumerator()
        {
            for (int i = 0; i < size; i++)
            {
                yield return new CreatureProxy(this, i);
            }
        }
    }


    public class Benchy
    {
        [Benchmark]
        public void SoA()
        {
            var creatures = new Creatures(1000);
            foreach (var creature in creatures)
            {
                creature.X++;
            }
        }

        [Benchmark]
        public void AoS()
        {
            var creatures = new Creature[1000];

            for (int i = 0; i < creatures.Length; i++)
            {
                creatures[i] = new Creature();
            }

            foreach (var creature in creatures)
            {
                creature.x++;
            }
        }
    }


    static void Main(string[] args)
    {
        //Array of structs
        //var creatures1 = new Creature[1000];

        //foreach (var creature in creatures1)
        //{
        //    creature.x++;
        //}

        ////AoS/SoA duality

        ////Struct of arrays
        //var creatures = new Creatures(1000);

        //foreach (var creature in creatures)
        //{
        //    creature.X++;
        //}

        BenchmarkRunner.Run<Benchy>();
    }
}
