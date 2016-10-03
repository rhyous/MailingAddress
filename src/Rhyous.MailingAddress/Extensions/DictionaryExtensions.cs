using Rhyous.StringLibrary;
using System.Collections.Generic;
using System.Text;

namespace Rhyous.MailingAddress.Extensions
{
    public static class DictionaryExtensions
    {
        public static string GetValueOrSame(this Dictionary<string, string> dictionary, string key)
        {
            string value;
            if (dictionary.TryGetValue(key.TrimAll(), out value))
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
