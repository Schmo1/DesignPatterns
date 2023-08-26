namespace GenericValueAdapter
{
    internal class Program
    {
        public class VectorOfFloat<TSelf,D> 
            : Vector<TSelf,float, D>
            where D : IInteger, new()
            where TSelf : Vector<TSelf,float,D>, new()
        {
        }

        public class VectorOfInt<D> :Vector<VectorOfInt<D>, int, D>
            where D :IInteger, new()
        {
            public VectorOfInt()
            {
                    
            }

            public VectorOfInt(params int[] values) : base(values)
            {

            }

            public static VectorOfInt<D> operator+
                (VectorOfInt<D> lhs, VectorOfInt<D> rhs)
            {
                var result = new VectorOfInt<D>();
                var dim = new D().Value;

                for(int i = 0; i < dim; i++)
                {
                    result[i] = lhs.data[i] + rhs.data[i];
                }

                return result;

            }
        }

        public class Vector2i : VectorOfInt<Dimensions.Two> 
        {
            public Vector2i()
            {
                    
            }

            public Vector2i(params int[] values) : base(values)
            {
                    
            }
     
        }

        public class Vector3f : VectorOfFloat<Vector3f,Dimensions.Three>
        {
            public override string ToString()
            {
                return $"{string.Join(",", data)}";
            }
        }
        



        static void Main(string[] args)
        {
            var v = new Vector2i();
            v[1] = 2;

            var vv = new Vector2i(3,4);

            var result = v + vv;

            var u = Vector3f.Create(3.5f,2.2f,1);

            
        }


    }
} 