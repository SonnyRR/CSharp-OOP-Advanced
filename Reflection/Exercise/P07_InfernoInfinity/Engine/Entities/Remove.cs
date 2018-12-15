namespace P07_InfernoInfinity.Engine.Entities
{
    using System;
    using System.Linq;
    using Weapons;

    public class Remove : ICommand
    {
        private IRepository repo;

        public Remove(string[] data, IRepository repo)
        {
            this.repo = repo;
            this.IndexToRemove = int.Parse(data[1]);
            this.WeaponName = data[0];
        }

        public int IndexToRemove { get; private set; }

        public string WeaponName { get; private set; }

        public bool Execute()
        {
            Weapon weapon = this.repo.Weapons
                .FirstOrDefault(x => x.Name == this.WeaponName);

            bool isSuccessfulDeletion = weapon.RemoveGem(this.IndexToRemove);

            return isSuccessfulDeletion;
        }
    }
}
