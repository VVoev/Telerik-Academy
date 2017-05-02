namespace SchoolSystem.Tests.Models
{
    using CLI.Exceptions;
    using CLI.Models.Contracts;
    using Moq;
    using NUnit.Framework;
    using SchoolSystemCli.Models;
    using SchoolSystemCli.Models.Enums;
    using System.Linq;
    using Моcks;
    [TestFixture]

    public class TeacherTests
    {
        [Test]
        public void CreatingNewTeacher_ShouldPass()
        {
            var teacher = new Teacher("Petar", "Marinov", Subject.Bulgarian);
            Assert.IsInstanceOf<Teacher>(teacher);
        }

        [Test]
        public void TeacherShouldThrowException_WhenFirstNameIsTooShort()
        {
            Assert.Throws<NameExceptions>(() => new Teacher("a", "Ivailo", Subject.Bulgarian));
        }

        [Test]
        public void TeacherShouldThrowException_WhenSecondNameIsTooShort()
        {
            Assert.Throws<NameExceptions>(() => new Teacher("Ivailo", "a", Subject.Bulgarian));
        }

        [TestCase("Petar1")]
        [TestCase("V1ct0r")]
        [TestCase("Оснхд")]
        public void TeacherShouldThrowException_WhenNameContainSyombolsDifferenFromEnglishAlfabet(string name)
        {
            Assert.Throws<NameExceptions>(() => new Teacher(name, "a", Subject.Bulgarian));
        }

        [Test]
        public void StudentShouldHaveMark_WhenTeacherAddMark()
        {
            var studentMock = new MockedStudent("Petar", "Marinov", Grade.Twelfth);
            var markMock = new Mock<IMark>();


            markMock.Setup(x => x.MarkExam).Returns(4);
            markMock.Setup(x => x.Subject).Returns(Subject.Bulgarian);

            var teacher = new Teacher("Ivan", "Goshov", Subject.Bulgarian);
            teacher.AddMark(studentMock, 4f);

            Assert.AreEqual(markMock.Object.MarkExam, studentMock.Marks.First().MarkExam);
            Assert.AreEqual(markMock.Object.Subject, studentMock.Marks.First().Subject);
        }
    }
}
