using Moq;
using NUnit.Framework;
using System;
using Tasker.Core.Contracts;
using Tasker.Core.Models;

namespace Tasker.Tests.Core.TaskManager
{
    [TestFixture]
    class AddTests
    {
        [Test]
        [Category("Manager")]
        public void Add_ShouldThrowNullException_WhenPassedNullValue()
        {
            var idProviderStub = new Mock<IIdProvider>();
            var consoleLoggerStrub = new Mock<ILogger>();
            var sut = new TaskManager(idProviderStub.Object, consoleLoggerStrub.Object);

            Assert.Throws<ArgumentNullException>(() => sut.Add(null));
        }

        [Test]
        [TestCase(1)]
        [TestCase(5)]
        [Category("Manager")]
        public void Add_ShouldAssignIdToProvidedTask_WhenValidTaskIsPassed(int expectedValue)
        {
            // Arrange
            var taskMock = new Mock<ITask>();
            var idProviderStub = new Mock<IIdProvider>();
            var consoleLoggerStub = new Mock<ILogger>();
            idProviderStub.Setup(x => x.NextId()).Returns(expectedValue);

            var sut = new TaskManager(idProviderStub.Object, consoleLoggerStub.Object);

            // Act
            sut.Add(taskMock.Object);

            // Assert
            taskMock.VerifySet(x => x.ID = expectedValue);
        }


    }
}
