namespace P07_InfernoInfinity.Weapons
{
    using System;
    using P07_InfernoInfinity.Enums;

    public class Sword : Weapon
    {
        private const int MIN_DMG = 4;
        private const int MAX_DMG = 6;
        private const int SOCKETS = 3;

        public Sword(string name, Rarity rarity)
            : base(name, MIN_DMG, MAX_DMG, rarity, SOCKETS)
        {

        }
    }
}
