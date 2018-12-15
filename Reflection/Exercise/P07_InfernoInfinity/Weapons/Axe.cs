namespace P07_InfernoInfinity.Weapons
{
    using System;
    using P07_InfernoInfinity.Enums;

    public class Axe : Weapon
    {
        private const int MIN_DMG = 5;
        private const int MAX_DMG = 10;
        private const int SOCKETS = 4;

        public Axe(string name, Rarity rarity) 
            : base(name, MIN_DMG, MAX_DMG, rarity, SOCKETS)
        {

        }
    }
}
