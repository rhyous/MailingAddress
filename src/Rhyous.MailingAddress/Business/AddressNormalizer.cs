using System;

namespace Rhyous.MailingAddress
{
    public class AddressNormalizer : IAddressNormalizer
    {
        AddressNormalizerCollection NormalizerCollection;

        public AddressNormalizer(AddressNormalizerCollection normalizerCollection)
        {
            NormalizerCollection = normalizerCollection;
        }

        public T Normalize<T>(T address)
                where T : IAddress, new()
        {
            // Test if reflection has any performance issues. If not, use reflection.
            //var normalizedAddress = new T();
            //foreach (var prop in typeof(IAddress).GetProperties())
            //{
            //    prop.SetValue(normalizedAddress, NormalizerCollection[prop.Name].Normalize(prop.GetValue(address).ToString()));
            //}
            return new T()
            {
                Street1 = NormalizerCollection["Street1"].Normalize(address.Street1),
                Street2 = NormalizerCollection["Street2"].Normalize(address.Street2),
                City = NormalizerCollection["City"].Normalize(address.City),
                State = NormalizerCollection["State"].Normalize(address.State),
                Country = NormalizerCollection["Country"].Normalize(address.Country),
                PostalCode = NormalizerCollection["PostalCode"].Normalize(address.PostalCode)
            };
        }

        public string Normalize(string value)
        {
            throw new NotImplementedException();
        }
    }
}
