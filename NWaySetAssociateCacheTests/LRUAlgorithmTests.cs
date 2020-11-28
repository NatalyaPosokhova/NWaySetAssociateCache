﻿using NUnit.Framework;
using NWaySetAssociateCache;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using System;

namespace NWaySetAssociateCacheTests
{
    public class LRUAlgorithmTests
    {
        [Test]
        public void AddEntryToHashMapShouldBeSuccess()
        {
            //Arrange
            int cacheSize = 16;
            int key = 55;
            int expectedValue = 4;
            var algorithm = new LRUAlgorithm<int>(cacheSize);

            algorithm.Add(key, expectedValue);

            //Actual
            var actualValue = algorithm.GetValue(key);
            //Assert
            Assert.AreEqual(expectedValue, actualValue);
        }

        [Test]
        public void AddEntryViaCacheShouldBeSuccess()
        {
            //Arrange
            int cacheSize = 16;
            int nSet = 3;
            string key1 = "key1";
            string expectedValue1 = "value1";
            string key2 = "key2";
            string expectedValue2 = "value2";
            string key3 = "key3";
            string expectedValue3 = "value3";

            var algorithm = new LRUAlgorithm<string>(cacheSize);

            var cache = new Cache<string>(cacheSize, nSet, algorithm);
            cache.Put(key1, expectedValue1);
            cache.Put(key2, expectedValue2);
            cache.Put(key3, expectedValue3);

            //Actual
            var actualValue1 = algorithm.GetValue(key1);
            var actualValue2 = algorithm.GetValue(key2);
            var actualValue3 = algorithm.GetValue(key3);

            //Assert
            Assert.AreEqual(expectedValue1, actualValue1);
            Assert.AreEqual(expectedValue2, actualValue2);
            Assert.AreEqual(expectedValue3, actualValue3);
        }

        [Test]
        public void TryGetFromNullCacheShouldBeErrorTest()
        {
            //Arrange
            int cacheSize = 10;
            int nSet = 5;
            string key = "134";

            var algorithm = new LRUAlgorithm<string>(cacheSize);
            var cache = new Cache<string>(cacheSize, nSet, algorithm);

            //Actual
            //Assert
            Assert.Throws<InvalidOperationException>(() => algorithm.GetValue(key));
        }

        [Test]
        public void GetEntryViaCacheShouldBeFirst()
        {
            //Arrange
            int cacheSize = 256;
            int nSet = 5;
            string key1 = "1";
            string value1 = "1";
            string key2 = "2";
            string value2 = "2";
            int expectedOrder = 0;

            var algorithm = new LRUAlgorithm<string>(cacheSize);

            var cache = new Cache<string>(cacheSize, nSet, algorithm);

            cache.Put(key1, value1);
            cache.Put(key2, value2);
            cache.Get(key1);

            //Actual
            var actualOrder = algorithm.GetKeyValueHashMapOrder(key1);

            //Assert
            Assert.AreEqual(expectedOrder, actualOrder);
        }

        [Test]
        public void RemoveEntryViaAlgorithmShouldBeSuccess()
        {
            //Arrange
            int cacheSize = 255;
            int nSet = 1;
            double key = 6.4;
            double value = 2.2;

            var algorithm = new LRUAlgorithm<double>(cacheSize);

            var cache = new Cache<double>(cacheSize, nSet, algorithm);
            cache.Put(key, value);

            algorithm.Remove(key);

            //Actual
            //Assert
            Assert.Throws<ArgumentNullException>(() => algorithm.GetValue(key));
            Assert.Throws<ArgumentNullException>(() => cache.Get(key));
        }

         [Test]
        public void TryRemoveNullEntryShouldBeError()
        {
            //Arrange
            int cacheSize = 45;
            int nSet = 5;
            string key = "1";
            string value = "1";
            string keyToRemove = "2";

            var algorithm = new LRUAlgorithm<string>(cacheSize);
            algorithm.Add(key, value);

            //Actual
            //Assert
            Assert.Throws<CacheException>(() => algorithm.Remove(keyToRemove));
        }

        [Test]
        public void UpdateEntryViaAlgorithmShouldBeFirst()
        {
            //Arrange
            int cacheSize = 200;
            int key1 = 1;
            int value1 = 1;
            int key2 = 2;
            int value2 = 2;
            int expectedOrder = 0;

            var algorithm = new LRUAlgorithm<int>(cacheSize);
            algorithm.Add(key1, value1);
            algorithm.Add(key2, value2);
            algorithm.Update(key1);

            //Actual
            var actualOrder = algorithm.GetKeyValueHashMapOrder(key1);

            //Assert
            Assert.AreEqual(expectedOrder, actualOrder);
        }

        [Test]
        public void TryUpdateAlreadyFirstEntryTest()
        {
            //Arrange
            int cacheSize = 10;
            int nSet = 5;
            string key = "134";
            string value = "2221";

            var algorithm = new LRUAlgorithm<string>(cacheSize);
            var cache = new Cache<string>(cacheSize, nSet, algorithm);
            cache.Put(key, value);

            //Actual
            //Assert
            Assert.DoesNotThrow(() => algorithm.Update(key));
        }

    }
}
