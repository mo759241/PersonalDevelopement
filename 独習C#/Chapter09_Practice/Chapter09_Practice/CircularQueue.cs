using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter09_Practice
{
    class CircularQueue : ICharQ
    {
        char[] queue;
        int putloc, getloc;

        public CircularQueue(int size)
        {
            queue = new char[size + 1];
            putloc = getloc = 0;
        }

        public char Get()
        {
            if (getloc == putloc)
            {
                Console.WriteLine(" -- Queue is empty");
                return (char)0;
            }
            getloc++;
            if (getloc == queue.Length)
                getloc = 0;
            return queue[getloc];

        }

        public void Put(char ch)
        {
            // putloc = getloc -1 もしくは、putloc = 配列末尾 & getloc = 配列先端
            if (putloc == getloc - 1 ||
                (putloc == queue.Length - 1 && getloc == 0))
            {
                Console.WriteLine(" -- Queue is gull.");
                return;
            }

            putloc++;
            // 末尾まで行ったら先頭に戻る
            if (putloc == queue.Length)
                putloc = 0;
            queue[putloc] = ch;
            return;

        }
    }
}
