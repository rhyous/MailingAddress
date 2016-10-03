namespace Rhyous.MailingAddress
{
    public interface IAddressComparer
    {
        IAddressComparisonResult Equals<T>(T leftAddress, T rightAddress) where T : IAddress, new();
    }
}
