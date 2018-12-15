namespace P07_InfernoInfinity.Weapons
{
    using P07_InfernoInfinity.Enums;
    using System;

    public class Knife : Weapon
    {
        private const int MIN_DMG = 3;
        private const int MAX_DMG = 4;
        private const int SOCKETS = 2;

        public Knife(string name, Rarity rarity)
            : base(name, MIN_DMG, MAX_DMG, rarity, SOCKETS)
        {

        }
    }
}
