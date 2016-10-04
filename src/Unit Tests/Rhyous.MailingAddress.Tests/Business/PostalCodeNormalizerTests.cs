using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Rhyous.MailingAddress.Tests
{
    [TestClass]
    public class PostalCodeNormalizerTests
    {
        public TestContext TestContext { get; set; }

        [TestMethod]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"Data\PostalCodes.csv", "PostalCodes#csv", DataAccessMethod.Sequential)]
        public void PostalCodeNormalizerTest1()
        {
            // Arrange
            var postalCode = TestContext.DataRow[0].ToString();
            var expected = TestContext.DataRow[1].ToString();
            var normalizer = new PostalCodeNormalizer();

            // Act
            var actual = normalizer.Normalize(postalCode);

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
