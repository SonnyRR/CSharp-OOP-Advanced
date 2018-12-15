namespace FestivalManager.Entities.Sets
{
    using FestivalManager.Entities.Contracts;
    using System;

    public class Long : Set, ISet
    {
        public Long(string name)
            : base(name, new TimeSpan(0, 60, 0))
        {

        }
    }
}
