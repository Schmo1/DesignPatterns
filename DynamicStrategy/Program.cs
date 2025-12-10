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

		public class TextProcessor
		{
			private StringBuilder sb = new();
			IListStrategy listStrategy;

			public void SetOutputFormat(OutputFormat format)
			{
				switch (format)
				{
					case OutputFormat.Html:
						listStrategy = new HtmlListStrategy();
						break;
					case OutputFormat.Markdown:
						listStrategy = new MarkdownListStrategy();
						break;
					default:
						throw new NotImplementedException();
				}
			}

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
			var tp = new TextProcessor();
			tp.SetOutputFormat(OutputFormat.Markdown);
			tp.AppendList(new[] { "foo", "bar", "baz" });
			Console.WriteLine(tp.ToString());

			tp.SetOutputFormat(OutputFormat.Html);
			tp.Clear();
			tp.AppendList(new[] { "foo", "bar", "baz" });
		}
	}
}
