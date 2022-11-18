using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter08_Practice
{
    class Program
    {
        static void Main(string[] args)
        {
            // Q14
            Shape[] shapeArray = { new Triangle2(100, 50),
                                   new Rectangle(10, 10),
                                   new Rectangle(10, 30) };
            foreach (var shape in shapeArray)
            {
                Console.WriteLine(shape.CalArea());
            }
        }
    }
}
