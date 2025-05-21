using System.Text;

namespace StringFormatter
{
	internal class Program
	{
		static void Main(string[] args)
		{
			var formattedString = new FormattedString("Hello World!");
			formattedString.Capitalize(7, 11);
			Console.WriteLine(formattedString.ToString());

			var betterFormattedString = new BetterFormattedString("Hello World!");
			betterFormattedString.GetRange(7, 11).Capitalized = true;
			Console.WriteLine(betterFormattedString.ToString());
		}

		public class FormattedString
		{
			private readonly string text;
			private readonly bool[] capitalized;

			public FormattedString(string input)
			{
				this.text = input;
				capitalized = new bool[input.Length];
			}

			public void Capitalize(int start, int end)
			{
				for (int i = start; i < end; i++)
				{
					capitalized[i] = true;
				}
			}

			public override string ToString()
			{
				var sb = new StringBuilder();

				for (int i = 0; i < text.Length; i++)
				{
					var c = text[i];
					sb.Append(capitalized[i] ? char.ToUpper(c) : c);
				}
				return sb.ToString();
			}
		}

		public class BetterFormattedString
		{
			private readonly string text;
			private readonly List<TextRange> formatting = [];

			public BetterFormattedString(string input)
			{
				this.text = input;
			}

			public TextRange GetRange(int start, int end)
			{
				var range = new TextRange
				{
					Start = start,
					End = end
				};
				formatting.Add(range);
				return range;

			}

			public override string ToString()
			{
				var sb = new StringBuilder();
				for (int i = 0; i < text.Length; i++)
				{
					var c = text[i];
					foreach (var range in formatting)
					{
						if (range.Covers(i))
						{
							if (range.Capitalized) c = char.ToUpper(c);
						}
					}
					sb.Append(c);

				}
				return sb.ToString();
			}
		}

		public class TextRange
		{
			public int Start, End;
			public bool Capitalized, Bold, Italic;
			public bool Covers(int position)
			{
				return position >= Start && position <= End;
			}
		}
	}
}
		