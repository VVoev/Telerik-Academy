using NUnit.Framework;
using Tasker.Core.Providers;

namespace Tasker.Tests.Core.Provider
{
    [TestFixture]
    public class IdProviderTests
    {
       [Category("Provider")]
       [TestCase(0)]
       [TestCase(1)]
       [TestCase(2)]

        [Test]
       public void NextIdShouldIncremenentValue_WhenInvoked(int value)
        {
            var sut = new IdProvider();
            var result = value;

            Assert.AreEqual(result, sut.NextId());
        }

    }
}
