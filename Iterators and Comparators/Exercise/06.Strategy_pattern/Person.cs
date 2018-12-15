namespace _06.Strategy_pattern
{
    using System;

    public class Person : IEquatable<Person>, IComparable<Person>
    {
        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public string Name { get; set; }
        public int Age { get; set; }

        public int CompareTo(Person other)
        {
            int value = this.Name.CompareTo(other.Name);

            if (value == 0)
            {
                value = this.Age.CompareTo(other.Age);
            }

            return value;
        }

        public bool Equals(Person other)
        {
            return this.Name == other.Name && this.Age == other.Age;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, Age);
        }

        public override string ToString()
        {
            return $"{this.Name} {this.Age}";
        }
    }
}
