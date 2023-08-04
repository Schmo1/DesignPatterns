namespace FacetedBuilder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var pb = new PersonBuilder();
            Person person = pb
                .Works.At("Schmo Development")
                    .AsA("Engineer")
                    .Earning(12000)
                .Lives.At("Kehlegg 149")
                    .WithPostCode("6850")
                    .In("Dornbirn");


            Console.WriteLine(person.ToString()) ;
        }
    }
}