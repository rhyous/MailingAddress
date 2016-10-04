using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Rhyous.MailingAddress.Tests.Model
{
    [TestClass]
    public class AddressNormalizerCollectionTests
    {
        [TestMethod]
        public void AddressNormalizerCollectionConstructorTest()
        {
            // Arrange
            // Act
            var addressDictionaries = new AddressDictionaries();
            var addressNormalizerCollection = new AddressNormalizerCollection(addressDictionaries);
            // Assert
            Assert.AreEqual(addressNormalizerCollection.Count, 7);
        }
    }
}
