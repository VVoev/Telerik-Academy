namespace SchoolSystem.Tests.Models
{
    using CLI.Exceptions;
    using Moq;
    using NUnit.Framework;
    using SchoolSystemCli.Models;
    using SchoolSystemCli.Models.Enums;
    using System;
    [TestFixture]

    class StudentsTests
    {
        [TestCase("Ivo")]
        [TestCase("AlaBalaNica")]
        [TestCase("IvoIvoIvoIIvoIvoIvoIIvoIvoIvoI")]
        public void CheckFirstWhenFirstNameIsInGivenRange(string name)
        {
            var student = new Student(name,"Rusev",Grade.Sixth);
        }

        [TestCase("Ivo")]
        [TestCase("AlaBalaNica")]
        [TestCase("IvoIvoIvoIIvoIvoIvoIIvoIvoIvoI")]
        public void CheckFirstWhenLastNameIsInGivenRange(string name)
        {
            var student = new Student("Ilian", name, Grade.Sixth);
        }

        [TestCase("I")]
        [TestCase("asdfghjklzxcvbnmqwertyuiolkjhgfdszxcvbnkjhgfdfghjasdfghjkqwertyujnbvcvbjkjhgfdfghjk")]
        public void StudentShouldThrowExceptio_WhenFirstNameIsNotValid(string name)
        {
            Assert.Throws<NameExceptions>(() => new Student(name, "someName", Grade.Eleventh));
        }

        [TestCase("I")]
        [TestCase("asdfghjklzxcvbnmqwertyuiolkjhgfdszxcvbnkjhgfdfghjasdfghjkqwertyujnbvcvbjkjhgfdfghjk")]
        public void StudentShouldThrowExceptio_WhenSecondNameIsNotValid(string name)
        {
            Assert.Throws<NameExceptions>(() => new Student("SomeName", name, Grade.Eleventh));
        }

        public void StudentShouldThrowExceptionIfNameContainDifferentFromLetter()
        {
            Assert.Throws<NameExceptions>(() => new Student("SomeName1", "Kiro", Grade.Eleventh));
        }

        [Test]
        public void StudentShouldHaveNoMarksByDefault()
        {
            var student = new Student("Ilian", "Ivanov", Grade.Sixth);
            Assert.AreEqual(student.Marks.Count, 0);
        }

        [Test]
        public void WhenCreatingNewStudentShouldPassCorrect()
        {
            var student = new Student("Ilian", "Ivanov", Grade.Sixth);
            Assert.IsInstanceOf<Student>(student);
            Assert.AreEqual((Grade)int.Parse("6"), Grade.Sixth);
        }
    }
}
