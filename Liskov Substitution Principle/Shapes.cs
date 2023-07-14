using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liskov_Substitution_Principle
{
    public class Rectangle
    {
        public virtual int Width { get; set; }
        public virtual int Height { get; set; }


        public Rectangle()
        {
            
        }

        public Rectangle(int with, int height)
        {
            Width = with;
            Height = height;
        }

        public override string? ToString()
        {
            return $"{nameof(Width)}: {Width}, {nameof(Height)}: {Height}";
        }
    }

    public class Square : Rectangle
    {
        public override int Width 
        {             
            set { base.Width = base.Height = value; } 
        }

        public override int Height
        {            
            set { base.Width = base.Height = value; }
        }
/*
        in this case, you can't use the base class

        public new int Width
        {
            set { base.Width = base.Height = value; }
        }

        public new int Height
        {
            set { base.Width = base.Height = value; }
        }

*/
    }


}
