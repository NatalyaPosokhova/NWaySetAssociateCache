using NUnit.Framework;
using NWaySetAssociateCache;
using System;

namespace NWaySetAssociateCacheTests
{
    public class MRUAlgorithmTests
    {
        [Test]
        public void AddEntryCasheListShouldBeSuccess()
        {
            //Arrange
            int key = 178;
            int expectedValue = 678;
            var algorithm = new MRUAlgorithm<int>();

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

            var algorithm = new MRUAlgorithm<string>();

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
    }
}
