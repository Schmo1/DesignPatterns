using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dependency_Inversion_Principle
{
    public enum Relationship
    {
        Parent, 
        Child,
        Siblin

    }

    public class Person
    {
        public string Name { get; set; }
        public DateTime DateOfBirth;
    }

    public interface IRelationshipsBrowser
    {
        IEnumerable<Person> FindAllChildrenOf(Person person);
    }

    //low-level
    public class Relationships : IRelationshipsBrowser
    {
        private List<(Person, Relationship, Person)> relationships = new List<(Person, Relationship, Person)> ();

        public void AddParentAndChild(Person person, Person child)
        {
            relationships.Add((person, Relationship.Parent, child));
        }

        public IEnumerable<Person> FindAllChildrenOf(Person person)
        {            
            foreach (var relation in relationships.Where(x => x.Item1.Name == person.Name && x.Item2 == Relationship.Parent))
            {
                yield return relation.Item3;
            }
        }

        public List<(Person, Relationship,Person)> GetRelationships => relationships;
    }

   

}
