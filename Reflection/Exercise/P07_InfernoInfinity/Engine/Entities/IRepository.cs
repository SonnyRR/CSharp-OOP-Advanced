namespace P07_InfernoInfinity.Engine.Entities
{
    using Weapons;
    using System.Collections.Generic;

    public interface IRepository
    {
        void Add(Weapon weapon);
        IReadOnlyCollection<Weapon> Weapons { get; }
    }
}
