namespace Sortable_Collection.Sorters
{
    using System;
    using System.Collections.Generic;

    using Contracts;

    public class Quicksorter<T> : ISorter<T>
        where T : IComparable<T>
    {
        public void Sort(List<T> collection)
        {
            int n = collection.Count - 1;
            this.QuickSortRecuirsion(collection, 0, n);
        }

        private void QuickSortRecuirsion(List<T> partition, int start, int end)
        {
            if (start >= end)
            {
                return;
            }

            int pivot = this.GetPivot(partition, start, end);
            this.QuickSortRecuirsion(partition, start, pivot);
            this.QuickSortRecuirsion(partition, pivot + 1, end);
        }

        private int GetPivot(List<T> partition, int start, int end)
        {
            T pivot = partition[start];
            int store = start;

            for (int i = store + 1; i <= end; i++)
            {
                if (pivot.CompareTo(partition[i]) > 0)
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