namespace PropertyProxy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }


    public class Creature
    {
        private Property<int> agility = new();
        public int Agility
        {
            get { return agility.Value; }
            set { agility.Value = value; }
        }

        public class Property<T> : IEquatable<Property<T>> where T : new()
        {
            private T _value;
            public T Value
            {
                get => _value;
                set
                {
                    if (Equals(_value)) return;

                    Console.WriteLine($"Assigning value to {value}");
                    _value = value;
                }
            }

            public Property() : this(Activator.CreateInstance<T>())
            {

            }


            public Property(T value)
            {
                _value = value;
            }

            public static implicit operator T(Property<T> property) => property.Value;

            public static implicit operator Property<T>(T value) => new Property<T>(value);

            public override int GetHashCode()
            {
                return Value.GetHashCode();
            }

            public bool Equals(Property<T>? other)
            {
                if (ReferenceEquals(null, other)) return false;
                if (ReferenceEquals(this, other)) return true;
                return EqualityComparer<T>.Default.Equals(Value, other);
            }

            public static bool operator ==(Property<T> left, Property<T> right)
            {
                return Equals(left, right);
            }
        }
    }

}
