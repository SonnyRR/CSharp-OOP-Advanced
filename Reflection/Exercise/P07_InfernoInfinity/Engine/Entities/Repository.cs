namespace P07_InfernoInfinity.Engine.Entities
{
    using System;
    using System.Collections.Generic;
    using P07_InfernoInfinity.Weapons;

    public class Repository : IRepository
    {
        private List<Weapon> weapons;

        public Repository()
        {
            this.weapons = new List<Weapon>();
        }

        public IReadOnlyCollection<Weapon> Weapons
        {
            get { return weapons; }
        }

        public void Add(Weapon weapon)
        {
            this.weapons.Add(weapon);
        }
    }
}
