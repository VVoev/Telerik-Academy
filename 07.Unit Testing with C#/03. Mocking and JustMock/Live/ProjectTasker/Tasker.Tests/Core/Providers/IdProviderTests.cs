using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasker.Core.Providers;

namespace Tasker.Tests.Core.Providers
{
    [TestFixture]
    public class IdProviderTests
    {
        [Test]
        [Category("Tasker")]
        public void NextId_ShouldReturnIncrementedValue_WhenInvoced()
        {
            var idProvider = new IdProvider();
            var resultOne = idProvider.NextId();
            var resultTwo = idProvider.NextId();
            Assert.IsTrue(1 == resultOne);
            Assert.IsTrue(2 == resultTwo);
        }
    }
}
