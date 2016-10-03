namespace Rhyous.MailingAddress
{
    public interface IStringComparison
    {
        string Left { get; set; }
        string Right { get; set; }
        string AreComparible { get; set; }
        string PossibleScore { get; set; }
        string Score { get; set; }
        bool Match { get; set; }
    }
}
