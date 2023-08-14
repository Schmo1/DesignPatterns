namespace AmbientContext
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var house = new Building();

            // gnd 3000
            using (new BuildingContext(3000))
            {
                house.Walls.Add(new Wall(new Point(0, 0), new Point(5000, 0)));
                house.Walls.Add(new Wall(new Point(0, 0), new Point(0, 4000)));

                //1st 3500
                using (new BuildingContext(3500))
                {
                    house.Walls.Add(new Wall(new Point(0, 0), new Point(6000, 0)));
                    house.Walls.Add(new Wall(new Point(0, 0), new Point(0, 4000)));
                }

            //gnd 3000
            
                house.Walls.Add(new Wall(new Point(5000, 0), new Point(5000, 4000)));
            }
            Console.WriteLine(house);

        }
    }
}