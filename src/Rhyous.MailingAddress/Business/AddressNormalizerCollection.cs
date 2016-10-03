using System.Collections.Generic;

namespace Rhyous.MailingAddress
{
    public class AddressNormalizerCollection : IAddressNormalizerCollection
    {
        Dictionary<string, string> CountryDictionary;
        Dictionary<string, string> StateDictionary;
        Dictionary<string, string> CityDictionary;
        Dictionary<string, string> StreetDictionary;

        public AddressNormalizerCollection(Dictionary<string, string> countryDictionary,
                                           Dictionary<string, string> stateDictionary,
                                           Dictionary<string, string> cityDictionary,
                                           Dictionary<string, string> streetDictionary,
                                           IStringNormalizer postalCodeNormalizer = null)
        {
            CountryDictionary = countryDictionary;
            StateDictionary = stateDictionary;
            CityDictionary = cityDictionary;
            StreetDictionary = streetDictionary;
            PostalCode = postalCodeNormalizer;
        }
        
        public IStringNormalizer Country
        {
            get { return _Country ?? (_Country = new StringNormalizer(CountryDictionary)); }
            set { _Country = value; }
        } private IStringNormalizer _Country;


        public IStringNormalizer State
        {
            get { return _State ?? (_State = new StringNormalizer(StateDictionary)); }
            set { _State = value; }
        } private IStringNormalizer _State;

        public IStringNormalizer City
        {
            get { return _City ?? (_City = new StringNormalizer(CityDictionary)); }
            set { _City = value; }
        } private IStringNormalizer _City;

        public IStringNormalizer Street
        {
            get { return _Street ?? (_Street = new StringNormalizer(StreetDictionary)); }
            set { _Street = value; }
        } private IStringNormalizer _Street;

        public IStringNormalizer PostalCode
        {
            get { return _PostalCode ?? (_PostalCode = new PostalCodeNormalizer()); }
            set { _PostalCode = value; }
        } private IStringNormalizer _PostalCode;
    }
}
