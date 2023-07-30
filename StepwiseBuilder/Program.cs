namespace StepwiseBuilder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var car = CarBuilder.Create() 
                .OfType(CarType.Crossover) //ISpecifyCarType 
                .WithWheels(18)     //ISpecifyWheelSize
                .Build();               //ISpecifyBuild
                                        
        }
    }
}