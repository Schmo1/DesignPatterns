namespace CompositeProxyWithArrayBackendProperty;

internal class Program
{
    static void Main(string[] args)
    {
       
    }

    public class  Masonry
    {
        //public bool pillars, walls, floors;

        public bool? All
        {
            get
            {
                if(flags.Skip(1).All(x => x == flags[0]))
                {
                    return flags[0];
                }     
                else
                {
                    return null;
                }
            }

            set
            {
                if (!value.HasValue)
                {
                    return;
                }
                for (int i = 0; i < flags.Length; i++)
                {
                    flags[i] = value.Value;
                }
            }
        }

        //public bool? All
        //{
        //    get
        //    {
        //        if(pillars == walls && floors == walls)
        //        {
        //            return true;
        //        }     
        //        else
        //        {
        //            return null;
        //        }
        //    }

        //    set
        //    {
        //        if(!value.HasValue)
        //        {
        //            return;
        //        }
   
        //        pillars = value.Value;
        //        walls = value.Value;
        //        floors = value.Value;                
        //    }
        //}

        private readonly bool[] flags = new bool[3];

        public bool Pillars
        {
            set => flags[0] = value;
            get => flags[0];
        }

        public bool Walls
        {
            set => flags[1] = value;
            get => flags[1];
        }


        public bool Floors
        {
            set => flags[2] = value;
            get => flags[2];
        }


    }
}
