using System.Collections;
using System.Collections.ObjectModel;

namespace NeuralNetwork;

internal class Program
{
	static void Main(string[] args)
	{
		Console.WriteLine("Hello, World!");
	}
}

public static class ExtensionMethods
{
	public static void ConnectTo(this IEnumerable<Neuron> self, IEnumerable<Neuron> other)
	{
		if(ReferenceEquals(self, other))
		{
			return;
		}

		foreach (var from in self)
		{
			foreach (var to in other)
			{
				from.Out.Add(to);
				to.In.Add(from);
			}
		}
	}
}

public class NeuronLayer : Collection<Neuron>
{

}

public class Neuron : IEnumerable<Neuron>
{
	public float Value;
	public List<Neuron> In, Out;



	public IEnumerator<Neuron> GetEnumerator()
	{
		yield return this;
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}
}
