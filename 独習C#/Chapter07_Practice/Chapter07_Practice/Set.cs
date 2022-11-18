using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter07_Practice
{
    class Set
    {
        char[] members;

        public int Length { get; private set; }

        public Set()
        {
            Length = 0;
        }

        public Set(int length)
        {
            members = new char[length];
            Length = 0;
        }

        public Set(Set set)
        {
            members = new char[set.Length];
            for (var i = 0; i < set.Length; i++)
                members[i] = set[i];
            Length = set.Length;
        }

        public char this[int index]
        {
            get
            {
                if (index > IntArray.Length - 1 || index < 0)
                {
                    Console.WriteLine("Index is out of range.");
                    return -1;
                }
                return IntArray[index];
            }
        }
    }
}
