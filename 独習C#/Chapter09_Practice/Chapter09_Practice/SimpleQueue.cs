using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter09_Practice
{
    // 文字用の簡単な固定サイズキュー
    class SimpleQueue : ICharQ
    {
        char[] queue; // キューデータを保持する配列
        int putloc, getloc; // put,get操作時の添え字

        public SimpleQueue(int size)
        {
            queue = new char[size + 1];
            putloc = getloc = 0;
        }

        public char Get()
        {
            if (getloc == putloc)
            {
                Console.WriteLine("Queue is empty.");
                return (char)0;
            }
            getloc++;
            return queue[getloc];
        }

        public void Put(char ch)
        {
            if (putloc == queue.Length - 1)
            {
                Console.WriteLine(" --- Queue is full.");
                return;
            }
        }
    }
}
