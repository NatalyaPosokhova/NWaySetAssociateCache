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
        public void TryPutDataToCacheShouldBeSuccess()
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
       
    }
}