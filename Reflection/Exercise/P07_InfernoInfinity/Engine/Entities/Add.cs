namespace P07_InfernoInfinity.Engine.Entities
{
    using System;
    using System.Linq;
    using System.Reflection;
    using Enums;
    using Gems;

    public class Add : ICommand
    {
        private IRepository repository;
        private string nameOfWeapon;

        public Add(string[] data, IRepository repo)
        {
            this.repository = repo;
            this.NameOfWeapon = data[0];
            this.IndexOfGemSlot = int.Parse(data[1]);

            var tempSplit = data[2].Split(' ', StringSplitOptions.RemoveEmptyEntries);
            this.GemName = tempSplit[1];

            Clarity temp;
            Clarity.TryParse(tempSplit[0], out temp);
            this.GemClarity = temp;
        }

        public string NameOfWeapon
        {
            get { return nameOfWeapon; }
            private set { nameOfWeapon = value; }
        }

        public int IndexOfGemSlot { get; private set; }

        public string GemName { get; private set; }

        public Clarity GemClarity { get; private set; }

        public bool Execute()
        {
            var weapon = this.repository.Weapons
                .FirstOrDefault(x => x.Name == this.NameOfWeapon);

            var typeOfGem = Assembly.GetCallingAssembly()
                .GetTypes()
                .FirstOrDefault(x => x.Name == this.GemName);


            var gem = (Gem)Activator.CreateInstance(typeOfGem, GemClarity);

            weapon.AddGem(this.IndexOfGemSlot, gem);

            return true;
        }
    }
}
