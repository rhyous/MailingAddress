using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhyous.MailingAddress.Dictionaries;

namespace Rhyous.MailingAddress.Tests
{
    [TestClass]
    public class AddressNormalizerTests
    {
        public TestContext TestContext { get; set; }

        [TestMethod]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"Data\Addresses.csv", "Addresses#csv", DataAccessMethod.Sequential)]
        public void AddressNormalizerTest1()
        {
            // Arrange
            var address = new Address
            {
                Street1 = TestContext.DataRow["A1_Street1"].ToString(),
                Street2 = TestContext.DataRow["A1_Street2"].ToString(),
                City = TestContext.DataRow["A1_City"].ToString(),
                State = TestContext.DataRow["A1_State"].ToString(),
                Country = TestContext.DataRow["A1_Country"].ToString(),
                PostalCode = TestContext.DataRow["A1_PostalCode"].ToString(),
            };
            var expectedAddress = new Address
            {
                Street1 = TestContext.DataRow["E1_Street1"].ToString(),
                Street2 = TestContext.DataRow["E1_Street2"].ToString(),
                City = TestContext.DataRow["E1_City"].ToString(),
                State = TestContext.DataRow["E1_State"].ToString(),
                Country = TestContext.DataRow["E1_Country"].ToString(),
                PostalCode = TestContext.DataRow["E1_PostalCode"].ToString(),
            };
            var addressDictionaries = new AddressDictionaries();
            addressDictionaries["Street1"] = new StreetDictionary();
            addressDictionaries["Street2"] = new StreetDictionary();
            addressDictionaries["city"] = new CityDictionary();
            addressDictionaries["state"] = new StateDictionary();
            addressDictionaries["Country"] = new CountryDictionary();
            var addressNormalizerCollection = new AddressNormalizerCollection(addressDictionaries);
            var addressNormalizer = new AddressNormalizer(addressNormalizerCollection);

            // Act
            var actual = addressNormalizer.Normalize(address);

            // Assert
            Assert.AreEqual(actual.Street1, expectedAddress.Street1);
            Assert.AreEqual(actual.Street2, expectedAddress.Street2);
            Assert.AreEqual(actual.City, expectedAddress.City);
            Assert.AreEqual(actual.State, expectedAddress.State);
            Assert.AreEqual(actual.Country, expectedAddress.Country);
            Assert.AreEqual(actual.PostalCode, expectedAddress.PostalCode);
        }
    }
}
