using System;

namespace Rhyous.MailingAddress
{
    public interface IStringComparer
    {
        IStringComparisonDetails Compare(string left, string right);
        IStringComparisonDetails Compare(string left, string right, StringComparison comparison);
    }
}
