using System;
using System.Collections.Generic;

namespace Rhyous.MailingAddress
{
    public class AddressDictionaries : Dictionary<string, Dictionary<string, string>>
    {
        public AddressDictionaries() : base(7, StringComparer.OrdinalIgnoreCase)
        {
            foreach (var prop in typeof(IAddress).GetProperties())
            {
                this[prop.Name] = new Dictionary<string, string>();
            }
        }

        new public Dictionary<string, string> this[string key]
        {
            get
            {
                return base[key];
            }
            internal set { base[key] = value; }
        }

        new internal void Add(string key, Dictionary<string, string> value)
        {
            base.Add(key, value);
        }
    }
}
