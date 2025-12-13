namespace EqualityAndComparisonStrategies
{
	class Person : IComparable<Person>, IComparable
	{
		public int Age;
		public int Id;
		public string Name;

		public Person(int age, int id, string name)
		{
			Age = age;
			Id = id;
			Name = name;			
		}

		public int CompareTo(Person? other)
		{
			if(ReferenceEquals(this, other)) return 0;
			if(ReferenceEquals(null, other)) return 1;
			return Id.CompareTo(other.Id);
		}

		public int CompareTo(object? obj)
		{
			if (ReferenceEquals(null, obj)) return 1;
			if (ReferenceEquals(this, obj)) return 0;
			return obj is Person other ? CompareTo(other) : throw new ArgumentException();
		}

		private sealed class NameRelationalComparer : IComparer<Person>
		{
			public int Compare(Person? x, Person? y)
			{
				if(ReferenceEquals (x, y)) return 0;
				if (ReferenceEquals(null, y)) return 1;
				if (ReferenceEquals(null, x)) return -1;
				return string.Compare (x.Name, y.Name, StringComparison.OrdinalIgnoreCase);
			}
		}

		public static IComparer<Person> NameComparer { get; } = new NameRelationalComparer();
	}

	internal class Program
	{
		static void Main(string[] args)
		{
			var people = new List<Person>();

			people.Sort(); // default

			people.Sort((x,y) => x.Name.CompareTo(y.Name));

			people.Sort(Person.NameComparer);
		}
	}
}
