namespace P07_InfernoInfinity.Gems
{
    using Enums;
    public class Amethyst : Gem
    {
        private const int STRENGTH = 2;
        private const int AGILITY = 8;
        private const int VITALITY = 4;

        public Amethyst(Clarity clarity)
            : base(STRENGTH, AGILITY, VITALITY, clarity)
        {

        }
    }
}
