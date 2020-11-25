using NUnit.Framework;
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
            string key = "key";
            string expectedValue = "value";

            var algorithm = new LRUAlgorithm<string>(cacheSize);

            var cache = new Cache<string>(cacheSize, nSet, algorithm);
            cache.Put(key, expectedValue);

            //Actual
            var actualValue = algorithm.GetValue(key);

            //Assert
            Assert.AreEqual(expectedValue, actualValue);
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
            algorithm.Add(key, value);
            algorithm.Remove(key);

            var cache = new Cache<double>(cacheSize, nSet, algorithm);

            //Actual
            //Assert
            Assert.Throws<ArgumentNullException>(() => algorithm.GetValue(key));
            Assert.Throws<ArgumentNullException>(() => cache.Get(key));
        }


    }
}
