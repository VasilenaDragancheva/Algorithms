namespace Sortable_Collection
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Contracts;

    public class SortableCollection<T>
        where T : IComparable<T>
    {
        public SortableCollection()
        {
        }

        public SortableCollection(IEnumerable<T> items)
        {
            this.Items = new List<T>();
            this.Items.AddRange(items);
        }

        public SortableCollection(params T[] items)
            : this(items.AsEnumerable())
        {
        }

        public List<T> Items { get; set; }

        public int Count
        {
            get
            {
                return this.Items.Count;
            }
        }

        public int BinarySearch(T item)
        {
            // TODO
            return 0;
        }

        public int InterpolationSearch(T item) 
        {
            
        }

        public void Shuffle()
        {
            throw new NotImplementedException();
        }

        public void Sort(ISorter<T> sorter)
        {
            sorter.Sort(this.Items);
        }

        public T[] ToArray()
        {
            return this.Items.ToArray();
        }

        public override string ToString()
        {
            return string.Format("[{0}]", string.Join(", ", this.Items));
        }
    }
}