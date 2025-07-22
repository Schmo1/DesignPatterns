namespace Observer;

public class Event
{

}

public class FallsIllEvent : Event
{
	public string Address { get; set; }
}

public class Person : IObservable<Event>
{
	private readonly HashSet<Subscription> _subscriptions = new();

	public IDisposable Subscribe(IObserver<Event> observer)
	{
		 var subscription = new Subscription(this, observer);
		_subscriptions.Add(subscription);
		return subscription;
	}

	public void FallIll()
	{
		foreach (var subscription in _subscriptions)
		{
			subscription.Observer.OnNext(new FallsIllEvent { Address = "123 Main St" });
		}
	}

	private class Subscription : IDisposable
	{
		private readonly Person _person;
		public IObserver<Event> Observer => _observer;
		private readonly IObserver<Event> _observer;

		public Subscription(Person person, IObserver<Event> observer)
		{
			_person = person;
			_observer = observer;
		}


		public void Dispose()
		{
			_person._subscriptions.Remove(this);
		}
	}
}

public class Program : IObserver<Event>
{
	static void Main(string[] args)
	{
		new Program();
	}

	public Program()
	{
		var person = new Person();
		IDisposable subscription = person.Subscribe(this);
		person.FallIll(); 
		 
	}

	public void OnCompleted()
	{
	}

	public void OnError(Exception error)
	{
	}

	public void OnNext(Event value)
	{
		 if (value is FallsIllEvent fallsIllEvent)
		{
			Console.WriteLine($"Person has fallen ill at {fallsIllEvent.Address}");
		}
		else
		{
			Console.WriteLine("Person has experienced an event");
		}
	}
}
