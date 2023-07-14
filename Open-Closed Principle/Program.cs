namespace Open_Closed_Principle
{
    internal class Program
    {




        static void Main(string[] args)
        {
            var apple = new Product("Apple", Color.Green, Size.Small);
            var tree = new Product("Tree", Color.Green, Size.Large);
            var house = new Product("House", Color.Blue, Size.Large);

            Product[] products = new Product[] {apple, tree, house};

            var pf = new ProductFilter();
            var bf = new BetterFilter();

            Console.WriteLine("Green products (wrong way): ");
            foreach (var product in pf.FilterByColor(products,Color.Green))
            {
                Console.WriteLine($" - {product.Name} is green");
            }

            Console.WriteLine("Large products (Better way): ");
            foreach (var product in bf.Filter(products,new ColorSpecification(Color.Green)))
            {
                Console.WriteLine($" - {product.Name} is green");
            }

            Console.WriteLine("Large blue items");
            
            foreach(var product in bf.Filter(products, new AndSpecification<Product>(new ColorSpecification(Color.Blue), new SizeSpecification(Size.Large)))){
                Console.WriteLine($" - {product.Name} is big and blue");
            }


        }
    }
}