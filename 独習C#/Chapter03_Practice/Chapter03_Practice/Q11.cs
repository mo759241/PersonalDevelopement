using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Chapter03_Practice
{
    class Q11
    {
        static void Main(string[] args)
        {
            Console.WriteLine(@"Enter Free Message !!");

            bool endFg;
            string enterStr = "";
            string convertStr = "";
            var convertCount = 0;

            do
            {
                var str = Console.ReadLine().Replace("\r\n", "");
                var charArray = str.ToCharArray();

                foreach (var charactor in charArray)
                {
                    if (Regex.IsMatch(charactor.ToString(), @"^[a-z]+$"))
                    {
                        convertStr += ConvertChar(charactor, 32, false);
                        convertCount++;
                    }
                    else if (Regex.IsMatch(charactor.ToString(), @"^[A-Z]+$"))
                    {
                        convertStr += ConvertChar(charactor, 32, true);
                        convertCount++;
                    }
                    else
                    {
                        convertStr += ConvertChar(charactor, 0, false);
                    }
                }

                enterStr += str + "\r\n";
                convertStr += "\r\n";

                endFg = enterStr.Contains('.');
            } while (!endFg);

            Console.WriteLine("EnterStr = " + enterStr);
            Console.WriteLine("ConvertStr = " + convertStr);
            Console.WriteLine("ConvertCount = " + convertCount);
        }

        public static char ConvertChar(char c, int ascDiff, bool isPlus)
        {
            if (isPlus)
            {
                return (char)(c + ascDiff);
            }
            else
            {
                return (char)(c - ascDiff);
            }
        }
    }
}
