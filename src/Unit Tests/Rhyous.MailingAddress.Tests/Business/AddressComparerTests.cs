using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhyous.MailingAddress.Dictionaries;
using System;

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
            var addressDictionaries = new AddressDictionaries();
            addressDictionaries["Street1"] = new StreetDictionary();
            addressDictionaries["Street2"] = new StreetDictionary();
            addressDictionaries["city"] = new CityDictionary();
            addressDictionaries["state"] = new StateDictionary();
            addressDictionaries["Country"] = new CountryDictionary();
            var addressNormalizerCollection = new AddressNormalizerCollection(addressDictionaries);
            var addressNormalizer = new AddressNormalizer(addressNormalizerCollection);
            var comparer = new AddressComparer(addressNormalizer);
            var normalizer = new PostalCodeNormalizer();

            var overallMatch = Convert.ToBoolean(TestContext.DataRow["OverallMatch"]);
            var adjustedMatch = Convert.ToBoolean(TestContext.DataRow["AdjustedMatch"]);

            // Act
            var result = comparer.Equals(address1, address2);

            // Assert
            Assert.AreEqual(result.OverallMatch, overallMatch);
            Assert.AreEqual(result.AdjustedMatch, adjustedMatch);
        }       
    }
}
