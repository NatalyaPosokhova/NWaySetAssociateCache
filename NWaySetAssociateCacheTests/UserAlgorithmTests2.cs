﻿using NUnit.Framework;
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

        [Test]
        public void TryToUpdateShouldBeLast()
        {
            //Arrange
            var key1 = 111;
            string value1 = "111";
            var key2 = 222;
            string value2 = "222";

            userAlgorithm.Add(key1, value1);
            userAlgorithm.Add(key2, value2);
            userAlgorithm.Update(key1);

            //Actual
            //Assert
            Assert.IsTrue(userAlgorithm.IsKeyValuePairLast(key1));
        }

        [Test]
        public void TryToRemoveShouldBeNotExist()
        {
            //Arrange
            int cacheSize = 10;
            int nSet = 5;
            int key = 134;
            string value = "2221";

            var cache = new Cache<int, string>(cacheSize, nSet, userAlgorithm);
            cache.Put(key, value);

            //Actual
            userAlgorithm.Remove();

            //Assert
            Assert.Throws<InvalidOperationException>(() => userAlgorithm.GetValue(key));
        }
    }
}