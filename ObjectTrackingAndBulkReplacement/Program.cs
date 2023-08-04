namespace ObjectTrackingAndBulkReplacement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var factory = new TrackingThemeFactory();
            var theme1 = factory.CreateTheme(false);
            var theme2 = factory.CreateTheme(true);

            Console.WriteLine(factory.Info);


            var factory2 = new ReplaceableThemeFactory();
            var magicTheme = factory2.CreateTheme(true);
            Console.WriteLine(magicTheme.Value.BgrColor);

            factory2.ReplaceTheme(false);

            Console.WriteLine(magicTheme.Value.BgrColor);
        }
    }
}