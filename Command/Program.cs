using static Command.BankAccount;

namespace Command;

internal class Program
{
	static void Main(string[] args)
	{
		var ba = new BankAccount();
		var commands = new List<BankAccountCommand>
		{ 
			new BankAccountCommand(ba,BankAccountCommand.Action.Deposit,100),
			new BankAccountCommand(ba,BankAccountCommand.Action.Withdraw,50)

		};

        Console.WriteLine(ba);

		commands.ForEach(c => c.Call());

		Console.WriteLine(ba);

		foreach(var command in Enumerable.Reverse(commands))
		{
			command.Undo();
		}

		Console.WriteLine(ba);

    }
}

public class BankAccount
{
	private int balance;
	int overdraftLimit = -500;

	public void Deposit(int amount)
	{
		balance += amount;
		Console.WriteLine($"Deposited ${amount}, balance is now {balance}");
	}

	public bool Withdraw(int amount)
	{
		if (balance - amount >= overdraftLimit)
		{
			balance -= amount;
			Console.WriteLine($"Withdrew ${amount}, balance is now {balance}");
			return true;
		}
		return false;
	}

	public override string ToString()
	{
		return $"{nameof(balance)}: {balance}";
	}
}

	public interface ICommand
	{
		void Call();
		void Undo();
	}
	public class BankAccountCommand : ICommand
	{
		private BankAccount account;
		private Action action;
		private int amount;
		private bool succeeded;
		public enum Action
		{
			Deposit, Withdraw
		}

        public BankAccountCommand(BankAccount account, Action action, int amount)
        {
			this.account = account;
			this.action = action;
			this.amount = amount;
        }
        public void Call()
		{
			switch (action)
			{
				case Action.Deposit:
					account.Deposit(amount);
					succeeded = true;
					break;
				case Action.Withdraw:
					succeeded = account.Withdraw(amount);
					break;
				default:
					break;
			}
		}

	public void Undo()
	{
		if(!succeeded) { return; }
		switch (action)
		{
			case Action.Deposit:
				account.Withdraw(amount);
				break;
			case Action.Withdraw:
				account.Deposit(amount);
				break;
			default:
				break;
		}
	}
}

