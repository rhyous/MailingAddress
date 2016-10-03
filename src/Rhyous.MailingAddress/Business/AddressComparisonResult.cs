using System;
using System.Collections.Generic;

namespace Rhyous.MailingAddress
{
    public class AddressComparisonResult : List<IStringComparison>, IAddressComparisonResult
    {
        public bool AdjustedMatch { get; set; }

        public double AdjustedPossibleScore { get; set; }

        public double AdjustedScore { get; set; }

        public bool OverallMatch { get; set; }

        public double OverallPossibleScore { get; set; }

        public double OverallScore { get; set; }
    }
}
