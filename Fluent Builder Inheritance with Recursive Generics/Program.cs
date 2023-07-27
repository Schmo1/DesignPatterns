namespace Fluent_Builder_Inheritance_with_Recursive_Generics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var me = Person.New
                .Called("Schmo")
                .WorksAsA("developer")
                .Build();

            Console.WriteLine(me);
        }
    }
}