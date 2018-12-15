namespace _06.Strategy_pattern
{
    using System;
    using System.Collections.Generic;

    public class NameComparator : IComparer<Person>
    {
        public int Compare(Person x, Person y)
        {
            int isEqual = x.Name.Length.CompareTo(y.Name.Length);

            if (isEqual != 0)
            {
                return isEqual;
            }

            else
            {
                isEqual = x.Name.ToLower().CompareTo(y.Name.ToLower());
            }

            return isEqual;
        }
    }
}
