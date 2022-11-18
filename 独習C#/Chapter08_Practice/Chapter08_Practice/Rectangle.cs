using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter08_Practice
{
    class Rectangle : Shape
    {
        public Rectangle(int w, int h) : base(w, h) { }

        public override int CalArea()
        {
            return Width * Height;
        }
    }
}
