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
            algorithm.Received().Add(key, expectedValue);
            algorithm.Received().Update(key);
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

        [Test]
        public void TryGetNotExistedValueShouldBeError()
        {
            //Arrange
            var algorithm = Substitute.For<IAlgorithm<int>>();
            int cacheSize = 20;
            int nSet = 5;
            int key = 123;

            var cache = new Cache<int>(cacheSize, nSet, algorithm);

            //Actual
            //Assert
            Assert.Throws<CacheException>(() => cache.Get(key));
        }
        
        [Test]
        public void TryPutExistedKeyValuePairShouldBeError()
        {
            //Arrange
            var algorithm = Substitute.For<IAlgorithm<int>>();
            int cacheSize = 25;
            int nSet = 8;
            int key = 123;
            int value = 345;

            var cache = new Cache<int>(cacheSize, nSet, algorithm);
            cache.Put(key, value);

            //Actual
            //Assert
            Assert.Throws<CacheException>(() => cache.Put(key, value));
        }
    }
}