﻿namespace PrototypeInheritance
{
    public class Address : IDeepCopyable<Address>
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

        public void CopyTo(Address target)
        {
            target.StreetName = StreetName;
            target.HouseNumber = HouseNumber;
        }



        public override string ToString()
        {
            return $"{nameof(StreetName)}: {StreetName}, {nameof(HouseNumber)}: {HouseNumber}";
        }
    }

    public class Person : IDeepCopyable<Person>
    {
        public string[] Names;
        public Address Address;
        public Person(string[] names, Address address)
        {
            Names = names;
            Address = address;
        }
        public Person()
        {
                
        }

        public void CopyTo(Person target)
        {
            
            target.Names = (string[])Names.Clone();
            target.Address = Address.DeepCopy();
             
        }

  

        public override string ToString()
        {
            return $"{nameof(Names)}: {string.Join(" ", Names)},{nameof(Address)}: {Address} ";
        }
    }

    public class Employee : Person, IDeepCopyable<Employee>
    {
        public int Salary;

        public Employee()
        {
                
        }
        public Employee(string[] names, Address address, int salary) :base(names, address)
        {
                
        }

        public override string ToString()
        {
            return $"{base.ToString()}, {nameof(Salary)}: {Salary}";
        }


        public void CopyTo(Employee target)
        {
            base.CopyTo(target);
            target.Salary = Salary;
        }
    }

    public static class ExtensionMethods
    {
        public static T DeepCopy<T>(this IDeepCopyable<T> item) where T : new()
        {
            return item.DeepCopy();
        }

        public static T DeepCopy<T>(this T person)
            where T : Person, new()
        {
            return ((IDeepCopyable<T>)person).DeepCopy();
        }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            var john = new Employee();
            john.Names = new[] { "John", "Schmo" };
            john.Address = new Address{ HouseNumber = 123, StreetName = "Wallstreet" };
            john.Salary = 1000;

            var copy = john.DeepCopy();
            Employee e = john.DeepCopy<Employee>();
            Person p = john.DeepCopy<Person>();

            copy.Names[1] = "Smith";
            copy.Address.HouseNumber++;
            copy.Salary = 1234;

            Console.WriteLine(john);
            Console.WriteLine(copy);
        }
    }
}