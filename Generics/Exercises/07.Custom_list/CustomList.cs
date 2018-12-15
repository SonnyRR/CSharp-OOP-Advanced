namespace CustomList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class CustomList<T>  : IEnumerable<T>
        where T : IComparable<T>
    {
        private List<T> internalList;

        public CustomList()
        {
            this.internalList = new List<T>();
        }

        public IReadOnlyList<T> Values => this.internalList;
        public void Add(T item)
        {
            // TODO: Check if element is null;

            this.internalList.Add(item);
        }

        public void SwapElements(int firstIndex, int secondIndex)
        {
            // TODO : Check boundaries

            T firstTempElement = this.internalList[firstIndex];
            T secondTempElement = this.internalList[secondIndex];
            this.internalList[firstIndex] = secondTempElement;
            this.internalList[secondIndex] = firstTempElement;
        }

        public int GetGreaterThan(T item)
        {
            int count = 0;

            this.internalList.ForEach(x =>
            {
                if (item.CompareTo(x) < 0)
                {
                    count++;
                }
            });
            return count;
        }

        public bool Remove(int index)
        {
            // Using the default implementation of List<T>
            if (index < 0 || index >= this.internalList.Count)
            {
                return false;
            }

            this.internalList.RemoveAt(index);
            return true;
        }
        public void SortAscending()
        {
            this.internalList = this.internalList.OrderBy(x => x).ToList();
        }
        public bool Contains(T element)
        {
            return this.internalList.Contains(element);
        }
        public T Max()
        {
            return this.internalList.Max();
        }

        public T Min()
        {
            return this.internalList.Min();
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.internalList.Count; i++)
            {
                yield return this.internalList[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
        //public override string ToString()
        //{
        //    //StringBuilder builder = new StringBuilder();
        //    //this.internalList.ForEach(x => builder.AppendLine($"{typeof(T)}: {x}"));
        //    //return builder.ToString().TrimEnd();
        //}
    }
}
