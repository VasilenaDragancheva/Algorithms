namespace Sortable_Collection.Sorters
{
    using System;
    using System.Collections.Generic;

    using Sortable_Collection.Contracts;

    public class InPlaceMergeSorter<T> : ISorter<T>
        where T : IComparable<T>
    {
        public void Sort(List<T> collection)
        {

            this.InPlaceMergeSort(collection, 0, collection.Count - 1);
        }

        private void InPlaceMergeSort(List<T> collection, int start, int end)
        {
            if (start >= end)
            {
                return;
            }

            int mid = start + ((end - start) / 2);
            this.InPlaceMergeSort(collection, start, mid);
            this.InPlaceMergeSort(collection, mid + 1, end);

          

        }
    }
}
