
namespace ChatRoom
{
	internal class Program
	{
		public class Person
		{
			public string Name { get; set; }
			public ChatRoom Room { get; set; }

			private List<string> _chatLog = new List<string>();

			public Person(string name)
			{
				Name = name;
			}

			public void Say(string message)
			{
				Room.Broadcast(Name, message);
			}

			public void PrivateMessage(string who, string message)
			{
				Room.Message(Name, who, message);
			}

			public void Receive(string sender, string message)
			{
				var s = $"{sender}: '{message}'";
				_chatLog.Add(s);
				Console.WriteLine($"[{Name}'s chat session] {s}");
			}
		}

		public class ChatRoom
		{
			private List<Person> people = new List<Person>();
			public void Join(Person person)
			{
				string joinMsg = $"{person.Name} joins the chat";
				Broadcast("room", joinMsg);
				person.Room = this;
				people.Add(person);
			}

			public void Broadcast(string source, string message)
			{
				foreach (var p in people)
				{
					if (p.Name != source)
						p.Receive(source, message);
				}
			}

			public void Message(string source, string destination, string message)
			{
				people.Find(p => p.Name == destination)?.Receive(source, message);
			}
		}

		static void Main(string[] args)
		{
			var room = new ChatRoom();
			var john = new Person("John");
			var jane = new Person("Jane");
			room.Join(john);
			room.Join(jane);
			john.Say("hi room");
			jane.Say("oh, hey john");
			var simon = new Person("Simon");
			room.Join(simon);
			simon.Say("hi everyone!");
			jane.PrivateMessage("Simon", "glad you could join us!");
		}
	}
}
