using Moq;
using NUnit.Framework;
using ProjectManager.Common;
using ProjectManager.Common.Exceptions;
using ProjectManager.Contracts;
using ProjectManager.Core;
using ProjectManager.Core.Contacts;
using ProjectManager.Tests.Mocks;
using System;
using System.Collections.Generic;

namespace ProjectManager.Tests.EngineTests
{
    [TestFixture]
    public class EngineTests
    {
        [Test]
        public void StartShouldBeAbbleToReadCommands_WhenInvoked()
        {
            var engineProvider = new Mock<IEngineProvider>();
            Assert.DoesNotThrow(() => engineProvider.Object.Start());
        }

        [Test]
        public void StartShouldBeVeriedItIsInvoked_AtLeastOnce()
        {
            var engineProvider = new Mock<IEngine>();
            engineProvider.Setup(x => x.Start()).Verifiable();
        }

        [Test]
        public void ExecuteShouldBeInvokedAndThrowError_WhenWrongDataIsUsed()
        {
            var command = new Mock<ICommand>();
            Assert.Throws<UserValidationException>(() => command.Setup(x => x.Execute(new List<string>() { "wkjehejkwhejkw" })).Returns("Sasa"));   
        }
    }
}
