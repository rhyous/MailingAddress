using System;
using System.Collections.Generic;

namespace Rhyous.MailingAddress
{
    using Method = Action<string, AddressNormalizerCollection>;

    public class AddressNormalizerCollection : Dictionary<string, IStringNormalizer>
    {
        AddressDictionaries AddressDictionaries;
        IStringNormalizer PostCodeNormalizer;

        public AddressNormalizerCollection(AddressDictionaries addressDictionaries, IStringNormalizer postalCodeNormalizer = null)
        {
            AddressDictionaries = addressDictionaries;
            PostCodeNormalizer = postalCodeNormalizer;
            StringNormalizerBuilders = new Dictionary<string, Method>(StringComparer.OrdinalIgnoreCase)
            {
                { "Street1", StreetMethod},
                { "Street2", StreetMethod},
                { "PostalCode", PostalCodeMethod},
            };
            foreach (var key in addressDictionaries.Keys)
            {
                Method method;
                if (StringNormalizerBuilders.TryGetValue(key, out method))
                    method.Invoke(key, this);
                else
                    this[key] = new StringNormalizer(addressDictionaries[key]);
            }
        }

        public Dictionary<string, Method> StringNormalizerBuilders =
            new Dictionary<string, Method>(StringComparer.OrdinalIgnoreCase)
            {
                { "Street1", StreetMethod},
                { "Street2", StreetMethod},
                { "PostalCode", PostalCodeMethod},
            };

        internal static void StreetMethod(string key, AddressNormalizerCollection self)
        {
            self[key] = new WordNormalizer(new StringNormalizer(self.AddressDictionaries[key]));
        }

        internal static void PostalCodeMethod(string key, AddressNormalizerCollection self)
        {
            self[key] = self.PostCodeNormalizer ?? new PostalCodeNormalizer();
        }
    }
}
