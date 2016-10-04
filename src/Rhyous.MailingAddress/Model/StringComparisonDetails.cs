namespace Rhyous.MailingAddress
{
    public class StringComparisonDetails : IStringComparisonDetails
    {
        public string Left { get; set; }

        public string Right { get; set; }

        public bool AreComparible { get; set; }

        public double Score { get; set; }

        public double PossibleScore { get; set; }

        public bool Match { get; set; }
    }
}
