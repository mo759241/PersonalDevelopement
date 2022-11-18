using System;
using System.Linq;

namespace Chapter03_Practice
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(@"Enter Free Message !!");

            bool endFg;
            string enterStr = "";

            do
            {
                enterStr += Console.ReadLine() + "\r\n";
                endFg = enterStr.Contains('.');
            } while (!endFg);

            var spaceCount = enterStr.Length - enterStr.Replace(" ", "").Length;

            Console.WriteLine("EnterStr = " + enterStr);
            Console.WriteLine("Num of Space = " + spaceCount);
        }
    }
}
