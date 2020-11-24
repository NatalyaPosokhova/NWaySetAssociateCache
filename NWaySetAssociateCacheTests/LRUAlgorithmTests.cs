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
            var actualValue = algorithm.Get(key);
            //Assert
            Assert.AreEqual(expectedValue, actualValue);
        }
    }
}
