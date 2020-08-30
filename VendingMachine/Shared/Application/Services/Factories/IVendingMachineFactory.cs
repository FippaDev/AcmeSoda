namespace Services.Factories
{
    public interface IVendingMachineFactory
    {
        IVendingMachine BuildVendingMachine(string branding, string priceListFile);
    }
}