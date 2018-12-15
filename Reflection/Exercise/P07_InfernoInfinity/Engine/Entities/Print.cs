namespace P07_InfernoInfinity.Engine.Entities
{
    using System;
    using System.Linq;
    using Weapons;

    public class Print : ICommand
    {
        IRepository repo;
        private string name;

        public Print(string[] data, IRepository repo)
        {
            this.repo = repo;
            this.name = data[0];
        }

        public bool Execute()
        {
            var weapon = this.repo.Weapons.FirstOrDefault(x => x.Name == this.name);
            Console.WriteLine(weapon);
            return true;
        }
    }
}
