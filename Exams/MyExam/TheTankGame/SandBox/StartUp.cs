using System;

namespace SandBox
{
    
using TheTankGame.Entities.Parts.Contracts;
    using TheTankGame.Entities.Parts.Factories;
    using TheTankGame.Entities.Parts.Factories.Contracts;

    class StartUp
    {
        static void Main(string[] args)
        {
            IPartFactory factory = new PartFactory();
            IPart part = factory.CreatePart("Arsenal", "IDK", 232.44, 444.3131m, 200);
        }
    }
}
