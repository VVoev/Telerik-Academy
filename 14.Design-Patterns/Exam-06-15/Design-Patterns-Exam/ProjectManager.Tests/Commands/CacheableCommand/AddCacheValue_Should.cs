using Moq;
using NUnit.Framework;
using ProjectManager.Framework.Services;

namespace ProjectManager.Tests.Commands.CacheableCommands
{
    [TestFixture]
    public class AddCacheValue_Should
    {
        [Test]
        public void ShouldAddIsInvoked()
        {
            var cash = new Mock<ICachingService>();
            cash.Setup(x => x.AddCacheValue("xa", "xa", null)).Verifiable();
        }
    }
}
