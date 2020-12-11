using NUnit.Framework;
using System;
using NWaySetAssociateCache;

namespace NWaySetAssociateCacheTests
{
    [TestFixture]
    public class UserAlgorithmTests2
    {
        private UserAlgorithm<int, string> userAlgorithm;

        [SetUp]
        public void Setup()
        {
            userAlgorithm = new UserAlgorithm<int, string>((key) => UpdateAction.moveToEnd, (key, value) => AddAction.addToLast, () => RemoveAction.removeFirst);
        }

        [Test]
        public void TryAddEntyToUserCacheShouldBeSuccess()
        {
            //Arrange
            int key = 123;
            string expectedValue = "345";

            userAlgorithm.Add(key, expectedValue);

            //Actual
            var actualValue = userAlgorithm.GetValue(key);

            //Assert
            Assert.AreEqual(expectedValue, actualValue);
        }
    }
}
