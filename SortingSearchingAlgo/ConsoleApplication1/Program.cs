namespace ConsoleApplication1
{
    using System.Collections.Generic;

    class Program
    {
        static void Main(string[] args)
        {
            var copy = new List<int>() { 3, 44, 38, 5, 47, 15, 36, 26, 27, 2, 46, 4, 1, 19, 50, 48 };
            int n = copy.Count - 1;
            QuickSortRecuirsion(copy, 0, n);
        }

        private static void QuickSortRecuirsion(List<int> partition, int start, int end)
        {
            if (start >= end)
            {
                return;
                
            }

            int pivot = GetPivot(partition, start, end);
            QuickSortRecuirsion(partition, start, pivot);
            QuickSortRecuirsion(partition, pivot + 1, end);
        }

        public static int GetPivot(List<int> partition, int start, int end)
            {
            int pivot = partition[start];
            int store = start;

            for (int i = store + 1; i <= end; i++)
            {
                int currentNumber = partition[i];
                if (pivot.CompareTo(currentNumber) > 0)
                {
                    store++;
                    var smallerElement = partition[i];
                    partition[i] = partition[store];
                    partition[store] = smallerElement;
                   
                }
            }
            partition[start] = partition[store];
            partition[store] = pivot;
            return store;
        }
    }
}