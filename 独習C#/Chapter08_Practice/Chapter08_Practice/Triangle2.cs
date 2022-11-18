using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter08_Practice
{
    class Triangle2 : Shape
    {
        public Triangle2(int w, int h) : base(w, h) { }

        public override int CalArea()
        {
            return Width * Height / 2;
        }
    }
}
