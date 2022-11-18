namespace Chapter05_Practice
{
    class Bubble
    {
        public int[] BubbleSortArray(int[] array)
        {
            for (var a = 1; a < array.Length; a++)
            {
                for (var b = array.Length - 1; b >= a; b--)
                {
                    if (array[b - 1] > array[b])
                    {
                        var temp = array[b];
                        array[b] = array[b - 1];
                        array[b - 1] = temp;
                    }
                }
            }
            return array;
        }
        public string[] BubbleSortArray(string[] array)
        {
            for (var a = 1; a < array.Length; a++)
            {
                for (var b = array.Length - 1; b >= a; b--)
                {
                    if (array[b - 1].CompareTo(array[b]) > 0)
                    {
                        var temp = array[b];
                        array[b] = array[b - 1];
                        array[b - 1] = temp;
                    }
                }
            }
            return array;
        }
    }
}
