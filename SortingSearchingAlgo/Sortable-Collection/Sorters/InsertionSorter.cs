namespace Sortable_Collection.Sorters
{
    using System;
    using System.Collections.Generic;

    using Contracts;

    public class InsertionSorter<T> : ISorter<T>
        where T : IComparable<T>
    {
        public void Sort(List<T> collection)
        {
            int n = collection.Count;
            for (int i = 0; i < n; i++)
            {
                T element = collection[i];
                int currentIndex = i - 1;

                while (currentIndex >= 0 && element.CompareTo(collection[currentIndex]) < 0)
                {
                    currentIndex--;
                }

                if (currentIndex != i - 1)
                {
                    collection.RemoveAt(i);
                    collection.Insert(currentIndex + 1, element);
                }
            }
        }
    }
}