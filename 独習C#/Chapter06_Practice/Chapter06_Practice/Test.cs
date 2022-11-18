using System;
using System.Collections.Generic;
using System.Text;

namespace Chapter06_Practice
{
    class Test
    {
        private int a;
        public Test(int i)
        {
            a = i;
        }

        public static void Swap(ref Test test1, ref Test test2)
        {
            Console.WriteLine(test1.a + "：" + test2.a);

            var temp = test1.a;
            test1.a = test2.a;
            test2.a = temp;

            Console.WriteLine(test1.a + "：" + test2.a);
        }
    }
}
