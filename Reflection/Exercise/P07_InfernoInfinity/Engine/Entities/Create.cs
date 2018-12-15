namespace P07_InfernoInfinity.Engine.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using Enums;
    using Weapons;

    public class Create : ICommand
    {

        private Rarity rarity;
        private IRepository repository;

        public Create(string[] data, IRepository repo)
        {
            this.repository = repo;

            var tempSplit = data[0].Split(' ', StringSplitOptions.RemoveEmptyEntries);

            this.WeaponRarity = tempSplit[0];
            this.WeaponType = tempSplit[1];
            this.WeaponName = data[1];
        }

        public string WeaponType { get; }

        public string WeaponName { get; }

        public string WeaponRarity
        {
            get { return this.rarity.ToString(); }
            private set
            {
                if (!Rarity.TryParse(value, out this.rarity))
                {
                    throw new ArgumentException("Invalid rarity!");
                };
            }
        }

        public bool Execute()
        {
            var typeOfWeapon = Assembly.GetCallingAssembly()
                .GetTypes()
                .FirstOrDefault(x => x.Name == this.WeaponType);

            object[] args = { this.WeaponName, this.rarity };

            this.repository.Add((Weapon)Activator.CreateInstance(typeOfWeapon, args));
            return true;
        }
    }
}
