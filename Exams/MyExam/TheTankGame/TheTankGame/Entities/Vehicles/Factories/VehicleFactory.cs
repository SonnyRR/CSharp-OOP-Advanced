namespace TheTankGame.Entities.Vehicles.Factories
{
    using System;
    using System.Linq;
    using System.Reflection;
    using Entities.Miscellaneous;
    using Entities.Miscellaneous.Contracts;
    using Entities.Vehicles.Contracts;
    using Vehicles.Factories.Contracts;

    public class VehicleFactory : IVehicleFactory
    {
        public IVehicle CreateVehicle(string vehicleType, string model, double weight, decimal price, int attack, int defense, int hitPoints)
        {
            Type typeOfVehicle = Assembly.GetCallingAssembly()
                .GetTypes()
                .FirstOrDefault(x => x.Name == vehicleType && x.IsAbstract == false && typeof(IVehicle).IsAssignableFrom(x));

            // object args may not be in correct order

            IAssembler assembler = new VehicleAssembler();
            IVehicle vehicle = (IVehicle)Activator
                .CreateInstance(typeOfVehicle, new object[] { model, weight, price, attack, defense, hitPoints, assembler});
            return vehicle;
        }
    }
}
