using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter07_Practice
{
    class IndexerTest
    {
        int[] IntArray { get; set; }

        public IndexerTest(int[] array)
        {
            IntArray = new int[array.Length];
            for (var i = 0; i < array.Length; i++)
                IntArray[i] = array[i];
        }

        public int this[int index]
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
            set
            {
                if (index > IntArray.Length - 1 || index < 0)
                    Console.WriteLine("Failed set value because index is out of range.");
                IntArray[index] = value;
            }
        }
    }
}
