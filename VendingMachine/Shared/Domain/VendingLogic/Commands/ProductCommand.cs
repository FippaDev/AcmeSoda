﻿using System;
using Ardalis.GuardClauses;
using Fippa.Common.GuardClauses.Ardalis.GuardClauses;
using VendingMachine.Shared.Domain.Models.Commands;
using VendingMachine.Shared.Domain.Models.Stock;

namespace VendingMachine.Shared.Domain.VendingLogic.Commands
{
    /// <summary>
    /// A product, with a negative monetary value. E.g. Can of soda @-1.50
    /// </summary>
    public class ProductCommand : Command, IProductCommand
    {
        private StockItem _stockItem;

        public ProductCommand(StockItem stockItem, decimal value)
            : base(value)
        {
            Guard.Against.PositiveOrZero(value, nameof(value));
            _stockItem = stockItem;
        }

        public override void Execute()
        {
            throw new NotImplementedException();
        }

        public override void UnExecute()
        {
            throw new NotImplementedException();
        }
    }
}
