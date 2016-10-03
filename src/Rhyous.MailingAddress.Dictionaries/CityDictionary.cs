using System;
using System.Collections.Generic;

namespace Rhyous.MailingAddress.Dictionaries
{
    public class CityDictionary : Dictionary<string, string>
    {
        // Todo: Get this from a DB or elsewhere outside of code.
        public CityDictionary() : base(StringComparer.OrdinalIgnoreCase)
        {
            // Cardinal Directions
            Add("Los Angeles", "Los Angeles");
            Add("Los Ang.", "Los Angeles");
            Add("L.A.", "Los Angeles");
            Add("LA", "Los Angeles");

            Add("New York", "New York");
            Add("NY", "New York");
            Add("N.Y.", "New York");
        }
    }
}
