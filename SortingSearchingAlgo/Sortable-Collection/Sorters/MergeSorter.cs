namespace Sortable_Collection.Sorters
{
    using System;
    using System.Collections.Generic;

    using Contracts;

    public class MergeSorter<T> : ISorter<T>
        where T : IComparable<T>
    {
        public void Sort(List<T> collection)
        {
            this.MergeSort(collection, 0, collection.Count - 1);
        }

        private void MergeSort(List<T> collection, int start, int end)
        {
            if (start >= end)
            {
                return;
            }

            int mid = start + ((end - start) / 2);
            this.MergeSort(collection, start, mid);
            this.MergeSort(collection, mid + 1, end);

            T[] mergedArray = new T[end - start + 1];

            int leftIndex = start;
            int rightIndex = mid + 1;
            int merged = 0;
            while (leftIndex <= mid && rightIndex <= end)
            {
                if (collection[leftIndex].CompareTo(collection[rightIndex]) <= 0)
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
    }
}