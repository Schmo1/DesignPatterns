using System.Security.Cryptography.X509Certificates;

namespace Dependency_Inversion_Principle
{
    internal class Program
    {
        public class Research
        {
            //public Research(Relationships relationships)
            //{
            //var relations = relationships.GetRelationships;
            //foreach ( var relation in relations.Where(x => x.Item1.Name == "John" && x.Item2 == Relationship.Parent))
            //{
            //    Console.WriteLine($"{relation.Item3} is a child of {relation.Item1}");
            //}
            //}

            public Research(IRelationshipsBrowser browser)
            {
                foreach (var person in browser.FindAllChildrenOf(new Person() { Name = "John"}))
                {
                    Console.WriteLine($"{person.Name} is a child of John");
                }
            }
        }
       
        static void Main(string[] args)
        {
            var parent = new Person() { Name = "John" };
            var child1 = new Person() { Name = "Clara" };
            var child2 = new Person() { Name = "David" };


            var relationships = new Relationships();
            relationships.AddParentAndChild(parent, child1);
            relationships.AddParentAndChild(parent, child2);

            new Research(relationships);
        }
    }
}