namespace ConsoleApplication1
{
    using System.Collections.Generic;

    public class Program
    {
        public static void Sort(List<int> collection)
        {
            int end = collection.Count - 1;
            MergeSort(collection, 0, end);
        }

        private static void MergeSort(List<int> collection, int start, int end)
        {
            if (start >= end)
            {
                return;
            }

            int mid = start + ((end - start) / 2);
            MergeSort(collection, start, mid);
            MergeSort(collection, mid + 1, end);

            int[] mergedArray = new int[end - start + 1];

            int leftIndex = start;
            int rightIndex = mid + 1;
            int merged = 0;
            while (leftIndex <= mid && rightIndex <= end)
            {
                if (collection[leftIndex] <= collection[rightIndex])
                {
                    mergedArray[merged] = collection[leftIndex];
                    leftIndex++;
                }
                else
                {
                    mergedArray[merged] = collection[rightIndex];
                    rightIndex++;
                }

                merged++;
            }

            while (leftIndex <= mid)
            {
                mergedArray[merged] = collection[leftIndex];
                leftIndex++;
                merged++;
            }

            while (rightIndex <= end)
            {
                mergedArray[merged] = collection[rightIndex];
                rightIndex++;
                merged++;
            }

            for (int i = 0; i < mergedArray.Length; i++)
            {
                collection[start + i] = mergedArray[i];
            }
        }

        static void Main(string[] args)
        {
            // 3, 44, 38, 5, 47, 15, 36, 26,
            var collection = new List<int> { 3, 44, 38, 5, 47, 15, 36, 26, 27, 2, 46, 4, 19, 50, 48 };
            Sort(collection);
        }
    }
}