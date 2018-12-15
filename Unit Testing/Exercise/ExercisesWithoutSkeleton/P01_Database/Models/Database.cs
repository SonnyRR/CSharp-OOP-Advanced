namespace P01_Database.Models
{

    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Database
    {
        private const int size = 16;
        private int?[] internalArray;
        private int index;

        public Database()
        {
            this.internalArray = new int?[size];
            this.index = 0;
        }

        public Database(int[] values)
            : this()
        {
            if (values.Length > 16)
            {
                throw new InvalidOperationException("Input Array is too long.");
            }

            for (int i = 0; i < values.Length; i++)
            {
                this.internalArray[i] = values[i];
            }

            this.index = values.Length - 1;
        }

        public void Add(int number)
        {
            if (this.index < size - 1)
            {
                this.internalArray[++this.index] = number;
            }
            else
            {
                throw new InvalidOperationException("DB is full!");
            }
        }

        public void Remove()
        {
            if (this.index < 0)
            {
                throw new InvalidOperationException("DB is empty!");
            }

            this.internalArray[this.index] = null;
            this.index--;
        }

        public int[] Fetch()
        {
            return this.internalArray
                .Where(x => x != null)
                .Select(x => x.GetValueOrDefault())
                .ToArray();
        }
    }
}
