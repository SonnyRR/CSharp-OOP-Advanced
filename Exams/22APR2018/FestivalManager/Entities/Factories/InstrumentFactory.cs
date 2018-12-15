namespace FestivalManager.Entities.Factories
{
	using System;
	using System.Linq;
	using System.Reflection;
	using System.Runtime.InteropServices.WindowsRuntime;
	using Contracts;
	using Entities.Contracts;
	using Instruments;

	public class InstrumentFactory : IInstrumentFactory
	{
		public IInstrument CreateInstrument(string type)
		{
            var typeOfInstrument = Assembly.GetCallingAssembly()
                .GetTypes()
                .FirstOrDefault(x => x.Name == type 
                && typeof(IInstrument).IsAssignableFrom(x) == true 
                && x.IsAbstract == false);

            var instance = (IInstrument)Activator.CreateInstance(typeOfInstrument);
            return instance;
		}
	}
}