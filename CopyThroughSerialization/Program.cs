using System.Runtime.CompilerServices;
using System.Runtime.Serialization.Formatters.Binary;

namespace CopyThroughSerialization
{
    internal class Program
    {


        [Serializable]
        public class Person 
        {
            public string[] Names;
            public Address Addresse;

            public Person()
            {
                    
            }

            public Person(string[] name, Address address)
            {
                Names = name;
                Addresse = address;
            }

            //Copy construktor
            public Person(Person copy)
            {
                Names = copy.Names;
                Addresse = new Address(copy.Addresse);
            }

            public override string ToString()
            {
                return $"{nameof(Names)}: {string.Join(" ", Names)},{nameof(Addresse)}: {Addresse} ";
            }

 
        }


        [Serializable]
        public class Address
        {
            public string StreetName;
            public int HouseNumber;

            public Address()
            {

            }

            public Address(string streetName, int houseNumber)
            {
                StreetName = streetName;
                HouseNumber = houseNumber;
            }


            //copy construktor
            public Address(Address copy)
            {
                StreetName = copy.StreetName;
                HouseNumber = copy.HouseNumber;
            }

            public override string ToString()
            {
                return $"{nameof(StreetName)}: {StreetName}, {nameof(HouseNumber)}: {HouseNumber}";
            }


        }

        static void Main(string[] args)
        {
            var john = new Person(new string[] { "John", "Smith" }, new Address("Kehlegg", 123));


            Person david = john.DeepCopyJson();

            david.Names = new string[] { "David", "Schmoranz" };
            david.Addresse.StreetName = "Nenzing";
            david.Addresse.HouseNumber = 321;

            Console.WriteLine(john);
            Console.WriteLine(david);
        }
    }
}