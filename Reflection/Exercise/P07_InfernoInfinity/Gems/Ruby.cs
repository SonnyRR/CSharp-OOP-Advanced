namespace P07_InfernoInfinity.Gems
{
    using Enums;

    public class Ruby : Gem
    {
        private const int STRENGTH = 7;
        private const int AGILITY = 2;
        private const int VITALITY = 5;

        public Ruby(Clarity clarity)
            : base(STRENGTH, AGILITY, VITALITY, clarity)
        {

        }
    }
}
