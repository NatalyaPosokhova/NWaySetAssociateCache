using NUnit.Framework;
using NWaySetAssociateCache;
using NSubstitute;
using System.Collections.Generic;

namespace NWaySetAssociateCacheTests
{
    public class CacheTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TryPutGetDataToCacheShouldBeSuccess()
        {
            //Arrange
            var algorithm = Substitute.For<IAlgorithm<string>>();
            int cacheSize = 16;
            int nSet = 4;
            string key = "1";
            string expectedValue = "A";

            var cache = new Cache<string>(cacheSize, nSet, algorithm);
            cache.Put(key, expectedValue);

            //Actual
            var actualValue = cache.Get(key);

            //Assert
            Assert.AreEqual(expectedValue, actualValue);
        }

        [Test]
        public void TrySetTooMuchNWaysShouldBeError()
        {
            //Arrange
            var algorithm = Substitute.For<IAlgorithm<int>>();
            int cacheSize = 4;
            int nSet = 20;

            //Actual
            //Assert
            Assert.Throws<CacheException>(() => new Cache<int>(cacheSize, nSet, algorithm));
        }
    }
}