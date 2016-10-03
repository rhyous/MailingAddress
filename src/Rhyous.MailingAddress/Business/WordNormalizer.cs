using Rhyous.StringLibrary;
using System;
using System.Text;

namespace Rhyous.MailingAddress
{
    public class WordNormalizer : IStringNormalizer
    {
        public static char[] TrimCharacters = ". ".ToCharArray();
        private IStringNormalizer _Normalizer;

        public WordNormalizer(StringNormalizer normalizer)
        {
            _Normalizer = normalizer;
        }

        public string Normalize(string fullString)
        {
            var result = new StringBuilder();
            var words = fullString.TrimAll().Split(new char[0], StringSplitOptions.RemoveEmptyEntries);
            foreach (var word in words)
            {
                if (result.Length > 0)
                    result.Append(" ");
                result.Append(_Normalizer.Normalize(word.Trim(TrimCharacters)));
            }
            return result.ToString();
        }
    }
}
