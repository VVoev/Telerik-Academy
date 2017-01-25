namespace School.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using SchoolApplication;

    [TestClass]
    public class TestStudent
    {
        private const int minValue = 10000;
        private const int maxValue = 99999;
        private const string ValidName = "Tommy";

        [TestMethod]
        [TestCategory("Student")]
        public void Student_NotThrowingException_WhenCreatingValidStudent()
        {
            var student = new Student(ValidName, 15000);
        }

        [TestMethod]
        [TestCategory("Student")]
        public void Student_CreatingStudent_WhenUsingMinValue()
        {
            var student = new Student(ValidName, minValue);
        }

        [TestMethod]
        [TestCategory("Student")]
        public void Student_CreatingStudent_WhenUsingMaxValue()
        {
            var student = new Student(ValidName, maxValue);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [TestCategory("Student")]
        public void Student_CreatingStudentWillThrowException_WhenUsingMinValueMinusOne()
        {
            var student = new Student(ValidName, minValue-1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [TestCategory("Student")]
        public void Student_CreatingStudentWillThrowException_WhenUsingMaxValueMinusOne()
        {
            var student = new Student(ValidName, maxValue + 1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [TestCategory("Student")]
        public void Student_WillThrowException_WhenCreatingWithValueNull()
        {
            var student = new Student(null,15000);
        }

        [TestMethod]
        [TestCategory("Student")]
        [ExpectedException(typeof(ArgumentException))]
        public void Students_WillThrowException_WhenVisitingNullCourse()
        {
            var student = new Student(ValidName, minValue);
            Course course = new Course(null);
            course.AddStudentToCourse(student);
        }

        [TestMethod]
        [TestCategory("Student")]
        [ExpectedException(typeof(ArgumentException))]
        public void Students_WillThrowException_WhenRemovedFromCourse()
        {
            var student = new Student(ValidName, minValue);
            Course course = new Course(null);
            course.RemovestudentFromCourse(student);
        }

    }
}