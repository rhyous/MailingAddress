using Rhyous.StringLibrary;

namespace Rhyous.MailingAddress
{
    public class PostalCodeNormalizer : IStringNormalizer
    {
        public static int DefaultPostalCodeLength = 5;

        public int PostalCodeLength { get; set; } = DefaultPostalCodeLength;

        public string Normalize(string value)
        {
            return value.TrimAll().Substring(0, PostalCodeLength);
        }
    }
}
