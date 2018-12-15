namespace _03BarracksFactory
{
    using System;
    using Contracts;
    using Core;
    using Core.Factories;
    using Data;
    using Microsoft.Extensions.DependencyInjection;
    class AppEntryPoint
    {
        static void Main(string[] args)
        {
            IServiceProvider serviceProvider = ConfServices();
            ICommandInterpreter commandIntpr = new CommandInterpreter(serviceProvider);
            IRunnable engine = new Engine(commandIntpr);
            engine.Run();
        }

        private static IServiceProvider ConfServices()
        {
            IServiceCollection services = new ServiceCollection();
            services.AddTransient<IUnitFactory, UnitFactory>();

            services.AddSingleton<IRepository, UnitRepository>();

            IServiceProvider srvProvider = services.BuildServiceProvider();
            return srvProvider;
        }
    }
}
