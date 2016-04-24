namespace Sortable_Collection.Sorters
{
    using System;
    using System.Collections.Generic;

    using Contracts;

    public class HeapSorter<T> : ISorter<T>
        where T : IComparable<T>
    {
        public void Sort(List<T> collection)
        {
            this.BuildingHeap(collection);
            int swapIndex = collection.Count - 1;
            this.HeapSorting(collection, swapIndex);
        }

        private void HeapSorting(List<T> collection, int swapIndex)
        {
            if (swapIndex == 0)
            {
                return;
            }

            T maxProperty = collection[0];
            collection[0] = collection[swapIndex];
            collection[swapIndex] = maxProperty;
        }

        private void BuildingHeap(List<T> collection)
        {
        }
    }
}