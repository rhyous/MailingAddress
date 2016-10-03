using Rhyous.MailingAddress.Extensions;
using System.Collections.Generic;

namespace Rhyous.MailingAddress
{
    public class StringNormalizer : IStringNormalizer
    {
        Dictionary<string, string> dictionary;

        public StringNormalizer(Dictionary<string,string> dictionary)
        {
            this.dictionary = dictionary;
        }

        public string Normalize(string value)
        {
            return dictionary.GetValueOrSame(value);
        }
    }
}
