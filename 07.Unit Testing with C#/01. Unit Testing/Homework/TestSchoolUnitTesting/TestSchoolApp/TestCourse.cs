namespace TestSchoolApp
{

    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using SchoolApplication;
    using System.Linq;

    [TestClass]
    public class TestCourse
    {

        private  const string ValidCourse = "Programing";
        private  const string StudentValid = "Petar";
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [TestCategory("Course")]
        public void ShouldThrowException_WhenCreatingACourseWithNoName()
        {
            var course = new Course("");
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [TestCategory("Course")]
        public void ShouldThrowException_WhenCreatingACourseWithNameContainigSpaces()
        {
            var course = new Course("       ");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [TestCategory("Course")]
        public void ShouldThrowException_WhenCreatingACourseWithNameNull()
        {
            var course = new Course(null);
        }

        [TestMethod]
        [TestCategory("Course")]
        public void IncreasingStudensInCourse_WhenAddingStudents()
        {
            var course = new Course(ValidCourse);
            var student = new Student(StudentValid, 15000);
            course.AddStudentToCourse(student);

            Assert.AreEqual(1, course.NumberOfStudents.Count);
        }

        [TestMethod]
        [TestCategory("Course")]
        public void DecreasingStudensInCourse_WhenRemovingStudents()
        {
            var course = new Course(ValidCourse);
            var student1 = new Student(StudentValid, 15000);
            var student2 = new Student("Ivancho", 13000);
            course.AddStudentToCourse(student1);
            course.AddStudentToCourse(student2);
            course.RemovestudentFromCourse(student1);
            var sorted = course.NumberOfStudents.OrderBy(x => x.StudentID > 10000);
            Assert.AreEqual(sorted.Count(), 1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [TestCategory("Course")]
        public void CourseShouldThrowError_WhenTryingToRemoveNotExistingStudent()
        {
            var course = new Course(ValidCourse);
            var student = new Student("Petar", 15000);
            course.RemovestudentFromCourse(student);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [TestCategory("Course")]
        public void CourseShouldThrowError_WhenTryingToExceedLimitOf30People()
        {
            var course = new Course(ValidCourse);
            for (int i = 0; i < 32; i++)
            {
                course.AddStudentToCourse(new Student(StudentValid + i, 15000 + i));
            }
            
        }
    }
}
