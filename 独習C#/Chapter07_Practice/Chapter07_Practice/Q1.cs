using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter07_Practice
{
    class Q1
    {
        static void Main(string[] args)
        {
            // Q1
            Console.WriteLine("Q1 ------------------");

            var td = new ThreeD(1, 1, 1);
            td++;
            Console.WriteLine("X=" + td.X + "　Y=" + td.Y + "　Z=" + td.Z);

            Console.WriteLine("   ------------------");

            // Q4
            Console.WriteLine("Q4 ------------------");

            int[] intArray = { 1, 1, 1 };
            var it = new IndexerTest(intArray);
            it[2] = 2;
            for (var i = -2; i < 6; i++)
                Console.WriteLine(it[i]);

            Console.WriteLine("   ------------------");
        }
    }
}
