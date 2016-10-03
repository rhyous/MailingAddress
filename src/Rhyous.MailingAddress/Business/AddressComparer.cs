using System;

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

            var addressComparisonResult = new AddressComparisonResult();


            bool? result;
            int nullCount = 0;
            result = CompareIfAvailable(leftAddressNormalized.Country, rightAddressNormalized.Country, ref nullCount);

            result = CompareStrings(leftAddressNormalized.PostalCode, rightAddressNormalized.PostalCode);
            if (result != null && !result.Value)
            {
                //return false;
            }
            else if (result == null)
                nullCount++;

            return new AddressComparisonResult();

            //return leftAddressNormalized.Street1.Equals(rightAddressNormalized.Street1, StringComparison.OrdinalIgnoreCase)
            //    && leftAddressNormalized.Street2.Equals(rightAddressNormalized.Street2, StringComparison.OrdinalIgnoreCase)
            //    && leftAddressNormalized.City.Equals(rightAddressNormalized.City, StringComparison.OrdinalIgnoreCase)
            //    && leftAddressNormalized.State.Equals(rightAddressNormalized.State, StringComparison.OrdinalIgnoreCase)
            //    && leftAddressNormalized.Country.Equals(rightAddressNormalized.Country, StringComparison.OrdinalIgnoreCase)
            //    && leftAddressNormalized.PostalCode.Equals(rightAddressNormalized.PostalCode, StringComparison.OrdinalIgnoreCase);


            //var score = leftAddressNormalized.Street1.Equals(rightAddressNormalized.Street1, StringComparison.OrdinalIgnoreCase) ? 10 : 0;
            //score += leftAddressNormalized.Street2.Equals(rightAddressNormalized.Street2, StringComparison.OrdinalIgnoreCase) ? 10 : 0;
            //score += leftAddressNormalized.City.Equals(rightAddressNormalized.City, StringComparison.OrdinalIgnoreCase) ? 10 : 0;
            //score += leftAddressNormalized.State.Equals(rightAddressNormalized.State, StringComparison.OrdinalIgnoreCase) ? 10 : 0;
            //score += leftAddressNormalized.Country.Equals(rightAddressNormalized.Country, StringComparison.OrdinalIgnoreCase) ? 10 : 0;
            //score += leftAddressNormalized.PostalCode.Equals(rightAddressNormalized.PostalCode, StringComparison.OrdinalIgnoreCase); ? 10 : 0;
            //return score < 80;
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
