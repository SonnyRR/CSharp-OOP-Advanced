﻿namespace TheTankGame.Entities.Vehicles
{
    using System;
    using TheTankGame.Entities.Miscellaneous.Contracts;
    using TheTankGame.Entities.Vehicles.Contracts;

    public class Vanguard : BaseVehicle, IVehicle
    {
        public Vanguard(string model, double weight, decimal price, int attack, int defense, int hitPoints, IAssembler assembler) 
            : base(model, weight, price, attack, defense, hitPoints, assembler)
        {
        }
    }
}
