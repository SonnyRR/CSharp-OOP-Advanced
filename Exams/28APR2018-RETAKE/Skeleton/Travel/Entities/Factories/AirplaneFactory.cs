namespace Travel.Entities.Factories
{
    using System;
    using Contracts;
    using Airplanes.Contracts;
    using System.Reflection;
    using System.Linq;

    public class AirplaneFactory : IAirplaneFactory
    {
        public IAirplane CreateAirplane(string typeName)
        {
            Type type = Assembly.GetCallingAssembly()
                .GetTypes()
                .FirstOrDefault(x => x.Name == typeName
                && typeof(IAirplane).IsAssignableFrom(x) && x.IsAbstract == false);

            if (type == null)
            {
                throw new InvalidOperationException("Invalid airplane type!");
            }

            var instance = (IAirplane)Activator.CreateInstance(type);
            return instance;
        }
    }
}