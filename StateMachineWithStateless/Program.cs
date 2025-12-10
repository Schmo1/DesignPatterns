using Stateless;

namespace StateMachineWithStateless;

internal class Program
{
	public enum Health
	{
		NonReproducive,
		Pregnant,
		Reproductive
	}

	public enum Activity
	{
		ReachPuberty,
		GiveBirth,
		HaveAbortion,
		
	}

	static void Main(string[] args)
	{
		var machine = new StateMachine<Health, Activity>(Health.NonReproducive);

		machine.Configure(Health.NonReproducive)
			.Permit(Activity.ReachPuberty, Health.Reproductive);

		machine.Fire(Activity.ReachPuberty);
	}
}
