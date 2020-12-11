using NUnit.Framework;
using NWaySetAssociateCache;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NWaySetAssociateCacheTests
{
    [TestFixture]
    public class UserAlgorithmTests
    {
        private UserAlgorithm<int, string> userAlgorithm;

        [SetUp]
        public void Setup()
        {
            userAlgorithm = new UserAlgorithm<int, string>((key) => UpdateAction.moveToFirst, (key, value) => AddAction.addToFirst, () => RemoveAction.removeLast);
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
        public void TryToUpdateShouldBeFirst()
        {
            //Arrange
            var key = 567;
            userAlgorithm.Update(key);

            //Actual
            //Assert
            Assert.IsTrue(userAlgorithm.IsKeyValuePairFirst(key));
        }

        [Test]
        public void TryToRemoveShouldBeNotExist()
        {
            //Arrange
            var key = userAlgorithm.GetKeyToRemove();

            //Actual
            userAlgorithm.Remove();

            //Assert
            Assert.Throws<InvalidOperationException>(() => userAlgorithm.GetValue(key));
        }
    }
}
