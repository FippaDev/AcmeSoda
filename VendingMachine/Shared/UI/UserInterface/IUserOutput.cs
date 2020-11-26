using System.Collections.Generic;
using VendingMachine.Shared.Domain.Models.Stock;

namespace UserInterface
{
    public interface IUserOutput
    {
        void ShowBalance(decimal balance);
        void ShowWelcomeMessage(string manufacturer);
        void Message(string s);
        void ShowStockReport(IEnumerable<StockReportLine> stockLines);
    }
}
