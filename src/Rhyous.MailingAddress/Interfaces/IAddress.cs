namespace Rhyous.MailingAddress
{
    public interface IAddress
    {
        string Street1 { get; set; }
        string Street2 { get; set; }
        string City { get; set; }
        string State { get; set; }
        string Country { get; set; }
        string PostalCode { get; set; }
    }
}
