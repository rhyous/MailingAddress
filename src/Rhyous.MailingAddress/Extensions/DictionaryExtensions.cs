using Rhyous.StringLibrary;
using System.Collections.Generic;

namespace Rhyous.MailingAddress.Extensions
{
    public static class DictionaryExtensions
    {
        public static char[] TrimCharacters = ".\"".ToCharArray();

        public static string GetValueOrTrim(this Dictionary<string, string> dictionary, string key)
        {
            string value;
            key = key.TrimAll().Trim(TrimCharacters);
            if (dictionary.TryGetValue(key, out value))
                return value;
            return key;
        }

        public static T GetValueOrDefault<T>(this Dictionary<string, T> dictionary, string key, T defaultValue)
        {
            T value;
            if (dictionary.TryGetValue(key.TrimAll(), out value))
                return value;
            return defaultValue;
        }
    }
}
