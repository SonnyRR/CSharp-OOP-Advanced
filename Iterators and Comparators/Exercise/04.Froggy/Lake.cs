namespace _04.Froggy
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Lake<T> : IEnumerable<T>
    {
        private List<T> internalList;

        public Lake(ICollection<T> collection)
        {
            this.internalList = new List<T>(collection);
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.internalList.Count; i += 2)
            {
                yield return this.internalList[i];
            }

            int revIndex = this.internalList.Count % 2 != 0 
                ? (this.internalList.Count - 2) : (this.internalList.Count - 1);

            for (int i = revIndex; i >= 0; i -= 2)
            {
                yield return this.internalList[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
