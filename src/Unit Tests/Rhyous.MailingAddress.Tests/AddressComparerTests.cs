using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhyous.MailingAddress.Dictionaries;

namespace Rhyous.MailingAddress.Tests
{
    [TestClass]
    public class AddressComparerTests
    {
        public TestContext TestContext { get; set; }

        [TestMethod]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"Data\CompareAddresses.csv", "CompareAddresses#csv", DataAccessMethod.Sequential)]
        public void AddressComparerTest1()
        {
            // Arrange
            var address1 = new Address
            {
                Street1 = TestContext.DataRow["A1_Street1"].ToString(),
                Street2 = TestContext.DataRow["A1_Street2"].ToString(),
                City = TestContext.DataRow["A1_City"].ToString(),
                State = TestContext.DataRow["A1_State"].ToString(),
                Country = TestContext.DataRow["A1_Country"].ToString(),
                PostalCode = TestContext.DataRow["A1_PostalCode"].ToString(),
            };
            var address2 = new Address
            {
                Street1 = TestContext.DataRow["A2_Street1"].ToString(),
                Street2 = TestContext.DataRow["A2_Street2"].ToString(),
                City = TestContext.DataRow["A2_City"].ToString(),
                State = TestContext.DataRow["A2_State"].ToString(),
                Country = TestContext.DataRow["A2_Country"].ToString(),
                PostalCode = TestContext.DataRow["A2_PostalCode"].ToString(),
            };
            var streetDictionary = new StreetDictionary();
            var cityDictionary = new CityDictionary();
            var stateDictionary = new StateDictionary();
            var countryDictionary = new CountryDictionary();
            var addressNormalizerCollection = new AddressNormalizerCollection(countryDictionary, stateDictionary, cityDictionary, streetDictionary);
            var addressNormalizer = new AddressNormalizer(addressNormalizerCollection);
            var comparer = new AddressComparer(addressNormalizer);
            var normalizer = new PostalCodeNormalizer();

            // Act
            var result = comparer.Equals(address1, address2);

            // Assert
            Assert.IsTrue(result.OverallMatch);
        }
    }
}
