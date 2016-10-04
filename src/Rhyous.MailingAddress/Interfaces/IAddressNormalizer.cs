namespace Rhyous.MailingAddress
{
    public interface IAddressNormalizer
    {
        T Normalize<T>(T address) where T : IAddress, new();
    }
}
