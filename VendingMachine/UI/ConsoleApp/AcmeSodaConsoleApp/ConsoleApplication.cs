﻿using System.Diagnostics.CodeAnalysis;
using AcmeSodaConsoleApp.DependencyInjection;
using Fippa.DependencyInjection;
using Unity;
using Unity.Resolution;
using UserInterface;
using VendingMachine.Shared.Domain.Domain.VendingMachine;
using VendingMachine.Shared.Domain.Models;
using VendingMachine.Shared.Services.Factories;

namespace AcmeSodaConsoleApp
{
    [ExcludeFromCodeCoverage]
    public class ConsoleApplication : IConsoleApplication
    {
        private readonly IUnityContainer _container;
        private readonly IVendingMachine _vendingMachine;

        public ConsoleApplication(IUnityContainer container)
        {
            _container = container;
            var dispenserModule = _container.Resolve<SpiralDispenserModule>(
                new ResolverOverride[]
                {
                    new ParameterOverride("rows", 3),
                    new ParameterOverride("columns", 4)
                });

            var factory = container.Resolve<IVendingMachineFactory>();
            _vendingMachine = factory.BuildVendingMachine(dispenserModule, "Pepsi");
        }

        public void Run()
        {
            _vendingMachine.Initialise("pepsi.json");
            var input = _container.Resolve<IUserInput>();
            input.Run(_vendingMachine);
        }
    }
}
