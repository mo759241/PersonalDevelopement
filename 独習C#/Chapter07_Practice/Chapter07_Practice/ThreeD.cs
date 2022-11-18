using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter07_Practice
{
    class ThreeD
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }

        public ThreeD(int x, int y, int z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public static ThreeD operator ++(ThreeD td)
        {
            ThreeD newTd = new ThreeD(td.X, td.Y, td.Z);

            newTd.X++;
            newTd.Y++;
            newTd.Z++;

            return newTd;
        }
    }
}
