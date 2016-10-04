using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Rhyous.MailingAddress.Tests.Model
{
    [TestClass]
    public class AddressDictionariesTests
    {
        [TestMethod]
        public void AddressDictionariesConstructorTests()
        {
            // Arrange
            // Act
            var addressDictionaries = new AddressDictionaries();
            // Assert
            Assert.AreEqual(addressDictionaries.Count, 7);
        }
    }
}
