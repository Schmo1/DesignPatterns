using System.Text;

namespace CompositeGeometric
{
	internal class Program
	{
		static void Main(string[] args)
		{
			var drawing = new GeometricObject();
			drawing.Name = "My Drawing";

			drawing.Childrens.Add(new Square { _color = "Red" });
			drawing.Childrens.Add(new Circle { _color = "Blue" });

			var group = new GeometricObject();
			group.Childrens.Add(new Circle { _color = "Blue" });
			group.Childrens.Add(new Circle { _color = "Brown" });
			drawing.Childrens.Add(group);

			Console.WriteLine(drawing.ToString());
		}
	}


	public class GeometricObject
	{
		private Lazy<List<GeometricObject>> _childrens = new();

		public virtual string Name { get; set; } = "group";
		public string _color;
		public IList<GeometricObject> Childrens => _childrens.Value;

		public void Print(StringBuilder sb, int dept)
		{
			sb.Append(new String('*', dept ))
				.Append(Name)
				.AppendLine(string.IsNullOrWhiteSpace(_color) ? string.Empty : _color);

			foreach (var child in Childrens)
			{
				child.Print(sb, dept +1);
			}

		}

		public override string ToString()
		{
			var sb = new StringBuilder();
			Print(sb, 0);
			return sb.ToString();
		}
	}

	public class Square : GeometricObject
	{
		public override string Name => "Sqare";
	}

	public class Circle : GeometricObject
	{
		public override string Name => "Circle";
	}
}
