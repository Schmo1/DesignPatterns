using static System.Console;

namespace Prototype
{
    internal class Program
    {
        public class Person : IPrototype<Person>
        {
            public string[] Names;
            private Address Addresse;

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

            public Person DeepCopy()
            {
                return new Person(Names, Addresse.DeepCopy());
            }
        }

        public class Address: IPrototype<Address>
        {
            public string StreetName;
            public int HouseNumber;

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

            public Address DeepCopy()
            {
                return new Address(StreetName, HouseNumber);
            }
        }
        static void Main(string[] args)
        {
                var clara = new Person(new[] { "Clara", "Tschamon" }, new Address("Nenzing", 412));
                var john = new Person(new[] { "John", "Smith" }, new Address("Kehlegg", 123));

            var copyFromClara = new Person(clara);

            copyFromClara.Names = new[]{ "David", "Smith"};
            var anotherCopy = copyFromClara.DeepCopy();
        }
    }
}