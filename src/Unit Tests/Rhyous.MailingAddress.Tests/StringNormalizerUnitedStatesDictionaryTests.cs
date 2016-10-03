using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhyous.MailingAddress.Dictionaries;

namespace Rhyous.MailingAddress.Tests
{
    [TestClass]
    public class StringNormalizerUnitedStatesDictionaryTests
    {
        public TestContext TestContext { get; set; }

        [TestMethod]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"Data\StatesInUSA.csv", "StatesInUSA#csv", DataAccessMethod.Sequential)]
        public void StateNormalizerTest1()
        {
            // Arrange
            var state = TestContext.DataRow[0].ToString();
            var expected = TestContext.DataRow[1].ToString();
            var normalizer = new StringNormalizer(new StateDictionary());

            // Act
            var actual = normalizer.Normalize(state);

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
