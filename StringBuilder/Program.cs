namespace StringBuilder;

internal class Program
{
	static void Main(string[] args)
	{
		Console.WriteLine("Hello, World!");
	}
}

public class Lizard : ILizard
{
	public int Weight { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

	public void Crawl()
	{
		Console.WriteLine("Crawling"); ;
	}
}

public class Bird : IBird
{
	public int Weight { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

	public void Fly()
	{
		Console.WriteLine("Soaring in the sky");
	}
}

public class Dragon : IBird, ILizard
{
	private Lizard lizard = new();
	private Bird bird = new();

	public int Weight
	{
		get; set;
	}

	public void Crawl()
	{
		lizard.Crawl();
	}

	public void Fly()
	{
		bird.Fly();
	}
}


