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
    }
}
