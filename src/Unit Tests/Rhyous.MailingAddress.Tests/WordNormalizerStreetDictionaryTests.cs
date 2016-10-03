using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhyous.MailingAddress.Dictionaries;

namespace Rhyous.MailingAddress.Tests
{
    [TestClass]
    public class WordNormalizerStreetDictionaryTests
    {
        [TestMethod]
        public void StreetNormalizationTest1()
        {
            // Arrange
            var street1 = " 123 W " + Environment.NewLine + " 456 Nor.";
            var expected = "123 W 456 N";
            var normalizer = new WordNormalizer(new StringNormalizer(new StreetDictionary()));

            // Act
            var actual = normalizer.Normalize(street1);

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
