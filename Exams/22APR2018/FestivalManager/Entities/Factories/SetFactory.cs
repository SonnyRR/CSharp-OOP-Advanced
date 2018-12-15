using System;

using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace FestivalManager.Entities.Factories
{
	using Contracts;
	using Entities.Contracts;
	using Sets;

	public class SetFactory : ISetFactory
	{
		public ISet CreateSet(string name, string typeName)
		{
            var type = Assembly.GetCallingAssembly()
                .GetTypes()
                .FirstOrDefault(x => x.Name == typeName
                && typeof(ISet).IsAssignableFrom(x)
                && x.IsAbstract == false);

            var instance = (ISet)Activator.CreateInstance(type, new object[] { name });

            return instance;
		}
	}




}
