namespace Rhyous.MailingAddress
{
    interface IAddressNormalizerCollection
    {

        IStringNormalizer Country { get; set; }
        IStringNormalizer State { get; set; }
        IStringNormalizer City { get; set; }
        IStringNormalizer Street { get; set; }
        IStringNormalizer PostalCode { get; set; }
    }
}
