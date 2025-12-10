namespace SwitchExpression;

internal class Program
{
	enum Action
	{
		Open,
		Close
	}

	enum Chest
	{
		Open,
		Closed,
		Locked,
	}

	static Chest Manipulate(Chest chest, Action action, bool haveKey) => (chest, action, haveKey) switch
	{
		(Chest.Locked, Action.Open, true) => Chest.Open,
		(Chest.Closed, Action.Open, _) => Chest.Open,
		(Chest.Open, Action.Close, false) => Chest.Closed,
		(Chest.Open, Action.Close, true) => Chest.Locked,
		_=> chest
	};

	static void Main(string[] args)
	{
		var chest = Chest.Locked;
		Console.WriteLine($"Chest is {chest}");

		chest = Manipulate(chest, Action.Open, haveKey: true);
		Console.WriteLine($"Chest is {chest}");


		chest = Manipulate(chest, Action.Close, haveKey: false);
		Console.WriteLine($"Chest is {chest}");

		chest = Manipulate(chest, Action.Close, haveKey: false);
		Console.WriteLine($"Chest is {chest}");


	}
}
