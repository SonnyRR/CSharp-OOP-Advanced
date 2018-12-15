namespace P07_InfernoInfinity.Gems
{
    using Enums;

    public class Emerald : Gem
    {
        private const int STRENGTH = 1;
        private const int AGILITY = 4;
        private const int VITALITY = 9;

        public Emerald(Clarity clarity)
            : base(STRENGTH, AGILITY, VITALITY, clarity)
        {

        }
    }
}
