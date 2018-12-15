namespace Travel.Entities.Factories
{
    using System;
    using System.Linq;
    using System.Reflection;
    using Contracts;
	using Items.Contracts;

	public class ItemFactory : IItemFactory
	{
		public IItem CreateItem(string typeName)
		{
            Type type = Assembly.GetCallingAssembly()
                .GetTypes()
                .FirstOrDefault(x => x.Name == typeName
                && typeof(IItem).IsAssignableFrom(x) && x.IsAbstract == false);

            if (type == null)
            {
                throw new InvalidOperationException("Invalid item type!");
            }

            var instance = (IItem)Activator.CreateInstance(type);
            return instance;
        }
	}
}
