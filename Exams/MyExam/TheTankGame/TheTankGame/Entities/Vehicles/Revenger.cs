namespace TheTankGame.Entities.Vehicles
{
    using System;
    using TheTankGame.Entities.Miscellaneous.Contracts;
    using Vehicles.Contracts;

    public class Revenger : BaseVehicle, IVehicle
    {
        public Revenger(string model, double weight, decimal price, int attack, int defense, int hitPoints, IAssembler assembler) 
            : base(model, weight, price, attack, defense, hitPoints, assembler)
        {
        }
    }
}
