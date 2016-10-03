namespace Rhyous.MailingAddress.Model
{
    public class StringComparison : IStringComparison
    {
        public string Left { get; set; }
        public string Right { get; set; }
        public string AreComparible { get; set; }
        public string PossibleScore { get; set; }
        public string Score { get; set; }
        public bool Match { get; set; }
    }
}
