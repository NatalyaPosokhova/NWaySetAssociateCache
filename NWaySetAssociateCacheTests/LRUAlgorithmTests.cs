using NUnit.Framework;
using NWaySetAssociateCache;
using NSubstitute;

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
    }
}
