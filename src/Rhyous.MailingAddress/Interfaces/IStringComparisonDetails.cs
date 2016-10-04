namespace Rhyous.MailingAddress
{
    public interface IStringComparisonDetails
    {
        string Left { get; set; }

        string Right { get; set; }

        bool AreComparible { get; set; }

        double Score { get; set; }
        double PossibleScore { get; set; }

        bool Match { get; set; }
    }
}
