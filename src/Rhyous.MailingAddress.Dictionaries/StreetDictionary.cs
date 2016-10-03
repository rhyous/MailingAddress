using System;
using System.Collections.Generic;

namespace Rhyous.MailingAddress.Dictionaries
{
    public class StreetDictionary : Dictionary<string, string>
    {
        // Todo: Get this from a DB or elsewhere outside of code.
        public StreetDictionary() : base(StringComparer.OrdinalIgnoreCase)
        {
            // Cardinal Directions
            Add("N", "N");
            Add("Nor", "N");
            Add("North", "N");

            Add("S", "S");
            Add("South", "S");

            Add("E", "E");
            Add("East", "E");

            Add("W", "W");
            Add("West", "W");

            // Avenue
            Add("Avenue", "AVE");
            Add("Ave", "AVE");
            Add("Av", "AVE");

            // Street
            Add("ST", "ST");
            Add("Street", "ST");
            Add("Str", "ST");

            // Boulevard
            Add("Boulevard", "Boulevard");
            Add("Blvd", "Boulevard");
            Add("Boul", "Boulevard");
            Add("Boulv", "Boulevard");
        }
    }
}
