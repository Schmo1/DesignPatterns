namespace Switch
{
	internal class Program
	{
		enum State
		{
			Locked,
			Failed,
			Unlocked
		}
		static void Main(string[] args)
		{
			while (true)
			{
				State state = State.Locked;
				Console.Write("Enter password: ");
				string? password = Console.ReadLine();
				switch (state)
				{
					case State.Locked when password == "secret":
						state = State.Unlocked;
						goto case State.Unlocked;
						
					case State.Locked:
						state = State.Failed;
						break;
					case State.Failed:
						Console.WriteLine("Alarm! Incorrect password.");
						state = State.Locked;
						break;
					case State.Unlocked:
						Console.WriteLine("Door unlocked. Welcome!");
						state = State.Locked;
						break;
				}
			}
		}
	}
}
