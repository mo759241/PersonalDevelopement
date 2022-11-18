using System;

namespace Chapter01_Practice
{
    class CodeFile1
    {
        private const double MY_WEIGHT = 70.5;
        public static void Main()
        {
            // 月面における自分の体重
            var weightAtMoon = 70.5 * 0.17;
            Console.WriteLine("月面での自分の体重＝" + weightAtMoon);
        }
    }
}