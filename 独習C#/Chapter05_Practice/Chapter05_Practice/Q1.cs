using System;
using System.Linq;

namespace Chapter05_Practice
{
    class Q1
    {
        static void Main(string[] args)
        {
            // Q1
            var doubleArrayD1 = new double[12];

            // Q2

            var intArrayD2 = new int[4, 5];

            // Q3
            var intJagArrayD2 = new int[5][];

            // Q4
            int[] intArrayD1 = { 1, 2, 3, 4, 5 };

            // Q5
            // コレクションの要素を順に参照する。
            foreach (var element in intArrayD1) { }

            // Q6
            double[] doubleArrayD1_2 = { 1.1, 2.2, 3.3, 4.4, 5.5, 6.6, 7.7, 8.8, 9.9, 10.0 };
            var aveDoubleArrayD1_2 = doubleArrayD1_2.Average();
            Console.WriteLine(aveDoubleArrayD1_2);

            // Q7
            Console.WriteLine("Q7 ---------------");
            string[] stringArrayD1 = { "b", "c", "a", "z", "s", "m", "qowi", "vndis", "vsalm", @"/:.:", @".:::" };

            Console.WriteLine("Before sort：");
            foreach (var s in stringArrayD1)
                Console.Write(s + ", ");
            Console.WriteLine();

            stringArrayD1 = new Bubble().BubbleSortArray(stringArrayD1);
            Console.Write("After sort：");
            foreach (var s in stringArrayD1)
                Console.Write(s + ", ");
            Console.WriteLine();
            Console.WriteLine("   ---------------");

            Console.WriteLine();

            // Q8
            Console.WriteLine("Q8 ---------------");
            var str = "Test Message !! My name is Yuki Morita.";
            var key = "I want to encode string.";
            var code = new Code();

            var encodedStr = code.StringEncode(str, key);
            code.StringDecode(encodedStr, key);
            Console.WriteLine("   ---------------");
            Console.WriteLine();

        }
    }
}
