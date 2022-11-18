using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter09_Practice
{
    class Program
    {
        // Q9
        enum Planets { Mercury, Venus, Earth, Mars, Jupiter, Saturn, Uranus, Neptune };

        static void Main()
        {
            FailSoftArray fs = new FailSoftArray(5);
            int x;

            // Lengthを読み取ることができる
            for (int i = 0; i < (fs.Length); i++)
                fs[i] = i * 10;

            for (int i = 0; i < (fs.Length); i++)
            {
                x = fs[i];
                if (x != -1) Console.Write(x + " ");
            }
            Console.WriteLine();
        }
    }
}
