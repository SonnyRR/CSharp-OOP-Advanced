namespace _10.Tuple_implementation.Models
{
    using System;
    public class Threeuple<T1, T2, T3>
    {
        private T1 itemOne;
        private T2 itemTwo;
        private T3 itemThree;

        public Threeuple(T1 firstItem, T2 secondItem, T3 thirdItem)
        {
            this.Item1 = firstItem;
            this.Item2 = secondItem;
            this.Item3 = thirdItem;
        }

        public T1 Item1
        {
            get => this.itemOne;
            private set
            {
                this.itemOne = value;
            }
        }

        public T3 Item3
        {
            get => this.itemThree;
            private set
            {
                this.itemThree = value;
            }
        }

        public T2 Item2
        {
            get => this.itemTwo;
            private set
            {
                this.itemTwo = value;
            }
        }
    }
}
