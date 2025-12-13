namespace TemplateMethod
{

	public abstract class Game
	{
		protected abstract bool HaveWinner { get; }
		protected abstract int WinningPlayer { get; }
		public void Run()
		{
			Start();
			while (!HaveWinner)
			{
				TakeTurn();
			}

			Console.WriteLine($"Player {WinningPlayer} winns.");
		}

		protected abstract void Start();
		protected abstract void TakeTurn();


		protected int currentPlayer;
		protected readonly int numberOfPlayers;

		protected Game(int numberOfPlayers) 
		{
			this.numberOfPlayers = numberOfPlayers;
		}

	}

	public class Chess : Game
	{
		protected override bool HaveWinner => turn == maxTurns;

		protected override int WinningPlayer => currentPlayer;

		public Chess() : base(2)
		{
			
		}

		protected override void Start()
		{
			Console.WriteLine($"Starting chess game. Number of Players {numberOfPlayers}");
		}

		protected override void TakeTurn()
		{
			Console.WriteLine($"Turn {turn++} taken by player {currentPlayer}");
			currentPlayer = (currentPlayer + 1) % numberOfPlayers;
		}

		private int turn = 1;
		private int maxTurns = 10;
	}

	internal class Program
	{
		static void Main(string[] args)
		{
			var chess = new Chess();
			chess.Run();
		}
	}
}
