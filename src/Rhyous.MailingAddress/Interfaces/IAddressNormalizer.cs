namespace Rhyous.MailingAddress
{
    public interface IAddressNormalizer
    {
        T Normalize<T>(IAddress address) where T : IAddress, new();
    }
}
