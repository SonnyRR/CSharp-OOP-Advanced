namespace _03BarracksFactory.Core.Factories
{
    using System;
    using System.Linq;
    using System.Reflection;
    using Contracts;

    public class UnitFactory : IUnitFactory
    {
        public IUnit CreateUnit(string unitType)
        {
            //TODO: implement for Problem 3

            Type type = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(x => x.Name == unitType);

            if (type == null)
            {
                throw new ArgumentException("Invalid unit type!");
            }

            if (typeof(IUnit).IsAssignableFrom(type) == false)
            {
                throw new ArgumentException("UnitType is not a unit type!!");
            }

            return (IUnit)Activator.CreateInstance(type);
        }
    }
}
