namespace P02_ExtendedDatabase.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Database
    {
        private const int size = 16;
        private Person[] internalArray;
        private int index;

        public Database()
        {
            this.internalArray = new Person[size];
            this.index = -1;
        }

        public Database(Person[] values)
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

        public void Add(Person person)
        {
            if (this.index < size - 1)
            {

                if (this.internalArray.Where(x => x != null).Any(x => x.Name == person.Name))
                {
                    throw new InvalidOperationException("There is already a person with the same username!");
                }

                else if (this.internalArray.Where(x => x != null).Any(x => x.Id == person.Id))
                {
                    throw new InvalidOperationException("There is already a person with the same id!");
                }

                this.internalArray[++this.index] = person;
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

        public Person FindById(long id)
        {
            if (id < 0)
            {
                throw new ArgumentOutOfRangeException("Id is negative!");
            }

            Person person = this.internalArray.FirstOrDefault(x => x.Id == id);

            if (person == null)
            {
                throw new InvalidOperationException($"No user is present with id:{id}");
            }

            return person;
        }

        public Person FindByUsername(string username)
        {
            if (username == null)
            {
                throw new ArgumentNullException("Given username is null!");
            }

            Person person = this.internalArray.FirstOrDefault(x => x.Name == username);

            if (person == null)
            {
                throw new InvalidOperationException($"No user is present with id:{username}");
            }

            return person;
        }

        public Person[] Fetch()
        {
            return this.internalArray
                .Where(x => x != null)
                .ToArray();
        }
    }
}
