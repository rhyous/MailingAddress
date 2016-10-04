using System;
using System.Linq;
using StringComparer = Rhyous.MailingAddress.Business.StringComparer;

namespace Rhyous.MailingAddress
{
    public class AddressComparer : IAddressComparer
    {
        private IAddressNormalizer AddressNormalizer;

        public AddressComparer(AddressNormalizer addressNormalizer)
        {
            AddressNormalizer = addressNormalizer;
        }

        public IAddressComparisonResult Equals<T>(T leftAddress, T rightAddress) where T : IAddress, new()
        {
            var leftAddressNormalized = AddressNormalizer.Normalize<T>(leftAddress);
            var rightAddressNormalized = AddressNormalizer.Normalize<T>(rightAddress);

            var addressComparisonResult = new AddressComparisonResult
            {
                new StringComparer().Compare(leftAddressNormalized.Street1, rightAddressNormalized.Street1),
                new StringComparer().Compare(leftAddressNormalized.Street2, rightAddressNormalized.Street2),
                new StringComparer().Compare(leftAddressNormalized.City, rightAddressNormalized.City),
                new StringComparer().Compare(leftAddressNormalized.State, rightAddressNormalized.State),
                new StringComparer().Compare(leftAddressNormalized.Country, rightAddressNormalized.Country),
                new StringComparer().Compare(leftAddressNormalized.PostalCode, rightAddressNormalized.PostalCode)
            };

            addressComparisonResult.OverallPossibleScore = addressComparisonResult.Sum(scr => scr.PossibleScore);
            addressComparisonResult.OverallScore = addressComparisonResult.Sum(scr => scr.Score);
            addressComparisonResult.OverallMatch = addressComparisonResult.OverallScore == addressComparisonResult.OverallPossibleScore;

            addressComparisonResult.AdjustedScore = addressComparisonResult.Where(scr => scr.AreComparible).Sum(scr => scr.Score);
            addressComparisonResult.AdjustedPossibleScore = addressComparisonResult.Where(scr => scr.AreComparible).Sum(scr => scr.Score);
            addressComparisonResult.AdjustedMatch = addressComparisonResult.AdjustedScore == addressComparisonResult.AdjustedPossibleScore;

            return addressComparisonResult;
        }

        private static bool? CompareIfAvailable(string left, string right, ref int nullCount)
        {
            var result = CompareStrings(left, right);
            if (result != null && !result.Value)
            {
                return false;
            }
            else if (result == null)
            {
                nullCount++;
                return null;
            }
            return true;
        }

        private static bool? CompareStrings(string left, string right)
        {
            if (!string.IsNullOrWhiteSpace(left) && !string.IsNullOrWhiteSpace(right))
            {
                return left.Equals(right, StringComparison.OrdinalIgnoreCase);
            }
            return null;
        }
    }
}
