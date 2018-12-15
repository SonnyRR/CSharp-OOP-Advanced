namespace _01.ListIterator
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class ListIterator<T> : IEnumerable<T>
    {
        private readonly List<T> internalList;
        private int index;

        public ListIterator(ICollection<T> collection)
        {
            this.internalList = new List<T>(collection);
            this.index = 0;
        }

        public bool Move()
        {
            if (index + 1 >= this.internalList.Count)
            {
                return false;
            }

            this.index++;
            return true;
        }

        public bool HasNext()
        {
            if (this.index + 1 < this.internalList.Count)
            {
                return true;
            }

            return false;
        }

        public void Print()
        {
            string output = this.internalList.Count == 0 
                ? throw new ArgumentException("Invalid Operation!") : $"{this.internalList[this.index]}";
            Console.WriteLine(output);

        }

        public void PrintAll()
        {
            foreach (var item in this)
            {
                Console.Write($"{item} ");
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in this.internalList)
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
