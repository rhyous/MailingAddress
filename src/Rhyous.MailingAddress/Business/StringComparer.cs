using System;

namespace Rhyous.MailingAddress.Business
{
    public class StringComparer : IStringComparer
    {
        public StringComparer()
        {
            ScoreMethod = Score;
            PossibleScoreMethod = PossibleScore;
        }

        public Action<StringComparisonDetails> ScoreMethod { get; set; }
        public Action<StringComparisonDetails> PossibleScoreMethod { get; set; }

        public IStringComparisonDetails Compare(string left, string right)
        {
            return Compare(left, right, StringComparison.CurrentCultureIgnoreCase);
        }

        public IStringComparisonDetails Compare(string left, string right, StringComparison comparison)
        {
            var compareDetails = new StringComparisonDetails
            {
                Left = left,
                Right = right,
                AreComparible = AreComparible(left, right),
                Match = left.Equals(right, comparison)
            };
            PossibleScoreMethod.Invoke(compareDetails);
            ScoreMethod.Invoke(compareDetails);
            return compareDetails;
        }

        internal void Score(StringComparisonDetails details)
        {
            if (!details.AreComparible)
                details.Score = -1;
            else if (details.Match)
                details.Score = details.PossibleScore;
            else
                details.Score = 0;
        }

        internal void PossibleScore(StringComparisonDetails details)
        {
            details.PossibleScore = details.Left.Length + details.Right.Length;
        }

        internal bool AreComparible(string left, string right)
        {
            // If one is null or empty but the other is not, then they are not comparible
            return !((string.IsNullOrWhiteSpace(left) && !string.IsNullOrWhiteSpace(right))
            || (!string.IsNullOrWhiteSpace(left) && string.IsNullOrWhiteSpace(right)));
        }
    }
}
