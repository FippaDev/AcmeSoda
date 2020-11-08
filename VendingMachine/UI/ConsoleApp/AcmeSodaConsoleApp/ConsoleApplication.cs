﻿using System.Diagnostics.CodeAnalysis;
using UserInterface;
using VendingMachine.Shared.Domain.Domain.VendingMachine;
using VendingMachine.Shared.Domain.Models;
using VendingMachine.Shared.Services.Factories;

namespace AcmeSodaConsoleApp
{
    [ExcludeFromCodeCoverage]
    public class ConsoleApplication : IConsoleApplication
    {
        private readonly IUserInput _input;
        private readonly IVendingMachine _vendingMachine;

        public ConsoleApplication(IUserInput userInput, IUserOutput userOutput, IVendingMachineFactory factory)
        {
            var dispenserModule = new SpiralDispenserModule(6, 5);

            _input = userInput;
            _vendingMachine = factory.BuildVendingMachine(
                "Pepsi", 
                "pepsi.json");

            userOutput.ShowWelcomeMessage(_vendingMachine.Manufacturer);
        }

        public void Run()
        {
            _input.Run(_vendingMachine);
        }
    }
}
