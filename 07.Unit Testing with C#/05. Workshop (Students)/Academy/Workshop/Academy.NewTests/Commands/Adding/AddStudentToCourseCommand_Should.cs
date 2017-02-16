using Academy.Commands.Adding;
using Academy.Core.Contracts;
using Moq;
using NUnit.Framework;
using System;

namespace Academy.NewTests.Commands.Adding
{
    [TestFixture]
    public  class AddStudentToCourseCommand_Should
    {

        [Test]
        public void ShouldThrowArgumentNullException_WhenFactoryAProviderIsNull()
        {
            var factory = new Mock<IAcademyFactory>();
            var engine = new Mock<IEngine>();
            Assert.Throws<ArgumentNullException>(() => new AddStudentToCourseCommand(null, engine.Object));
        }
        [Test]
        public void ShouldThrowArgumentNullException_WhenEngineAProviderIsNull()
        {
            var factory = new Mock<IAcademyFactory>();
            var engine = new Mock<IEngine>();
            Assert.Throws<ArgumentNullException>(() => new AddStudentToCourseCommand(factory.Object, null));
        }

        [Test]
        public void ShouldThrowArgumentNullException_WhenEngineAProviderIsNullOrNotExisting()
        {
            var factory = new Mock<IAcademyFactory>();
            var engine = new Mock<IEngine>();
            Assert.Throws<ArgumentNullException>(() => new AddStudentToCourseCommand(null, null));
        }

        [Test]
        public void ShouldCorrectlyAssignValues_WhenBothProvidersIsNotNull()
        {
            var factory = new Mock<IAcademyFactory>();
            var engine = new Mock<IEngine>();
            var command =  new AddStudentToCourseCommandMock(factory.Object, engine.Object);

            Assert.AreEqual(engine.Object, command.Engine);
        }
        [Test]
        public void ShouldCorrectlyAssignValues_WhenBothProvidersIsNotNulls()
        {
            var factory = new Mock<IAcademyFactory>();
            var engine = new Mock<IEngine>();
            var command = new AddStudentToCourseCommandMock(factory.Object, engine.Object);

            Assert.AreEqual(factory.Object, command.Factory);
        }



    }
}
