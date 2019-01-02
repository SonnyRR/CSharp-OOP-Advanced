namespace TheTankGame.Entities.Parts.Factories
{
    using System;
    using System.Linq;
    using System.Reflection;
    using Parts.Factories.Contracts;
    using TheTankGame.Entities.Parts.Contracts;

    public class PartFactory : IPartFactory
    {
        public IPart CreatePart(string partType, string model, double weight, decimal price, int additionalParameter)
        {
            // If null what???
            Type typeOfPart = Assembly.GetCallingAssembly()
                .GetTypes()
                .FirstOrDefault(x => x.Name.Contains(partType) && x.IsAbstract == false && typeof(IPart).IsAssignableFrom(x));

            // object args may not be in correct order
            IPart part = (IPart)Activator.CreateInstance(typeOfPart, model, weight, price, additionalParameter);
            return part;
        }
    }
}
