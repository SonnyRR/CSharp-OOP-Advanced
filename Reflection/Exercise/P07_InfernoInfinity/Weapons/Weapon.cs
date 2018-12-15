namespace P07_InfernoInfinity.Weapons
{
    using System;
    using System.Collections.Generic;
    using Gems;
    using Enums;
    using System.Linq;
    using Engine.Entities;

    [Author("Pesho", 3, "Used for C# OOP Advanced Course - Enumerations and Attributes", "Pesho, Svetlio")]
    public abstract class Weapon
    {

        protected Weapon(string name, int minDmg, int maxDmg, Rarity rarity, int gemSlots)
        {
            this.Name = name;
            this.Rarity = rarity;
            this.gems = new Gem[gemSlots];
            this.MinDamage = minDmg * (int)this.Rarity;
            this.MaxDamage = maxDmg * (int)this.Rarity;
        }

        private int minDmg;
        private int maxDmg;

        public string Name { get; protected set; }

        public int MinDamage
        {
            get => this.minDmg;
            protected set
            {
                this.minDmg = value;
            }
        }

        public int MaxDamage
        {
            get => this.maxDmg;
            protected set
            {
                this.maxDmg = value;
            }
        }

        public Rarity Rarity { get; protected set; }

        protected Gem[] gems;

        public IReadOnlyCollection<Gem> Gems
        {
            get { return gems; }
        }

        public void AddGem(int index, Gem gem)
        {
            if (index < 0 || index >= this.gems.Length)
            {
                return;
            }

            this.gems[index] = gem;
        }

        public bool RemoveGem(int index)
        {
            if (index < 0 || index >= this.gems.Length)
            {
                return false;
            }

            var tempGem = this.gems[index];

            this.gems[index] = null;

            return true;
        }

        public override string ToString()
        {
            var strength = this.gems.Where(g => g != null).Select(g => g.Strength).Sum();
            var agility = this.gems.Where(g => g != null).Select(g => g.Agility).Sum();
            var vitality = this.gems.Where(g => g != null).Select(g => g.Vitality).Sum();

            var minDamage = this.MinDamage + (strength * 2) + agility;
            var maxDamage = this.MaxDamage + (strength * 3) + (agility * 4);

            return $"{this.Name}: {minDamage}-{maxDamage} Damage, +{strength} Strength, +{agility} Agility, +{vitality} Vitality";
        }

    }
}
