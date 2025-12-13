using System.Text;

namespace DynamicStrategy
{
	internal class Program
	{
		public enum OutputFormat
		{
			Markdown,
			Html,
		}

		public interface IListStrategy
		{
			void Start(StringBuilder sb);
			void End(StringBuilder sb);
			void AddItem(StringBuilder sb, string item);
		}

		public class HtmlListStrategy : IListStrategy
		{
			public void Start(StringBuilder sb)
			{
				sb.AppendLine("<ul>");
			}
			public void End(StringBuilder sb)
			{
				sb.AppendLine("</ul>");
			}
			public void AddItem(StringBuilder sb, string item)
			{
				sb.AppendLine($"  <li>{item}</li>");
			}
		}


		public class MarkdownListStrategy : IListStrategy
		{
			public void Start(StringBuilder sb) { }
			public void End(StringBuilder sb) { }
			public void AddItem(StringBuilder sb, string item)
			{
				sb.AppendLine($" * {item}");
			}
		}

		public class TextProcessor<LS> where LS : IListStrategy, new()
		{
			private StringBuilder sb = new();
			IListStrategy listStrategy = new LS();			

			public void Clear()
			{
				sb.Clear();
			}

			public void AppendList(IEnumerable<string> items)
			{
				listStrategy.Start(sb);
				foreach (var item in items)
				{
					listStrategy.AddItem(sb, item);
				}
				listStrategy.End(sb);
			}

			public override string ToString()
			{
				return sb.ToString();
			}
		}
		static void Main(string[] args)
		{
			var tp = new TextProcessor<MarkdownListStrategy>();
			tp.AppendList(new[] {"foo", "bar", "baz"});
			Console.WriteLine(tp);

			var tp2 = new TextProcessor<HtmlListStrategy>();
			tp2.AppendList(new[] { "foo", "bar", "baz" });
			Console.WriteLine(tp2);
		}
	}
}
