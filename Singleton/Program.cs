using MoreLinq;

namespace Singleton
{
    internal class Program
    {
        public interface IDatabase
        {
            int GetPopulation(string name);
        }

        public class SingletonDatabase : IDatabase
        {
            private Dictionary<string, int> capitals;
            private static Lazy<SingletonDatabase> instance = 
                new Lazy<SingletonDatabase>(() => new SingletonDatabase());
            public static SingletonDatabase Instance => instance.Value;

            private SingletonDatabase()
            {
                Console.WriteLine("Initializing database");

                capitals = File.ReadAllLines(
                            Path.Combine(
                                new FileInfo(typeof(IDatabase).Assembly.Location).DirectoryName,"capitals.txt"))
                          .Batch(2)
                          .ToDictionary(
                            list => list.ElementAt(0).Trim(),
                            list => int.Parse(list.ElementAt(1)));
            }



            public int GetPopulation(string name)
            {
                return capitals[name];
            }
        }
        static void Main(string[] args)
        {
            var db = SingletonDatabase.Instance;
            var city = "Tokyo";
            Console.WriteLine($"{city} has a population {db.GetPopulation(city)}");
        }
    }
}