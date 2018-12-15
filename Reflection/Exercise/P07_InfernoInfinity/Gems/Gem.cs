namespace P07_InfernoInfinity.Gems
{
    using System;
    using Enums;

    public abstract class Gem
    {
        protected Gem(int strength, int agility, int vitality, Clarity clarity)
        {
            int clarityMultiplier = (int)clarity;

            this.Strength = strength + clarityMultiplier;
            this.Agility = agility + clarityMultiplier;
            this.Vitality = vitality + clarityMultiplier;
        }

        public Clarity Clarity { get; protected set; }
        public int Strength { get; protected set; }

        public int Agility { get; protected set; }

        public int Vitality { get; protected set; }
    }
}
