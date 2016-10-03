using System.Collections.Generic;

namespace Rhyous.MailingAddress
{
    public interface IAddressComparisonResult : IList<IStringComparison>
    {
        bool OverallMatch { get; set; }
        double OverallScore { get; set; }
        double OverallPossibleScore { get; set; }

        bool AdjustedMatch { get; set; }
        double AdjustedPossibleScore { get; set; }
        double AdjustedScore { get; set; }
    }
}
