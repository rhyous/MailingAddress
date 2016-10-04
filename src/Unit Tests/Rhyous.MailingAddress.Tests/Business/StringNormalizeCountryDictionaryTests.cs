using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhyous.MailingAddress.Dictionaries;

namespace Rhyous.MailingAddress.Tests
{
    [TestClass]
    public class StringNormalizerCountryDictionaryTests
    {
        public TestContext TestContext { get; set; }

        [TestMethod]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"Data\Countries.csv", "Countries#csv", DataAccessMethod.Sequential)]
        public void CountryNormalizerTest1()
        {
            // Arrange
            var country = TestContext.DataRow[0].ToString();
            var expected = TestContext.DataRow[1].ToString();
            var normalizer = new StringNormalizer(new CountryDictionary());

            // Act
            var actual = normalizer.Normalize(country);

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
