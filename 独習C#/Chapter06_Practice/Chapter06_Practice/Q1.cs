using System;

namespace Chapter06_Practice
{
    class Q1
    {
        static void Main(string[] args)
        {
            // Q4
            Console.WriteLine("Q4 ----------------");

            var test1 = new Test(1);
            var test2 = new Test(2);

            Test.Swap(ref test1, ref test2);

            Console.WriteLine("   ----------------");

            // Q6
            Console.WriteLine("Q6 ----------------");

            var str = "Test string !!";
            Common.ReverseString(str);

            Console.WriteLine("   ----------------");
        }
    }
}
