namespace ProtectionProxy;

internal class Program
{
	static void Main(string[] args)
	{
		ICar car = new CarProxy(new Driver { Age = 18 });
	}
}

public interface ICar
{
	void Drive();
}
public class  Car
{
	public void Drive()
	{
		Console.WriteLine("Car is being driven");
	}
}


public class CarProxy : ICar
{
	private readonly Driver driver;
	private readonly Car car = new Car();

	public CarProxy(Driver driver)
	{
	
		this.driver = driver;
	}
	public void Drive()
	{
		if (driver.Age > 17)
		{
			car.Drive();
		}
		else
		{
			Console.WriteLine("Access denied");
		}
	}
}

public class Driver()
{
	public int Age { get; set; }
}