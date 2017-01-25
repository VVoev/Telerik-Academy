namespace TestSchoolApp
{

    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using SchoolApplication;
    using System.Linq;

    [TestClass]
    public class TestSchool
    {
        [TestMethod]
        [TestCategory("School")]
        public void SchoolNameCheck_ShouldReturnTrue_WhenValidNameIsUsed()
        {
            //Arrange
            var school = new School("Technical University");
            //Act
            var expected = "Technical University";
            var actual = school.SchoolName;
            //Assert
            Assert.AreEqual(expected, actual,"School names are not the same");
        }

        [TestMethod]
        [TestCategory("School")]
        [ExpectedException(typeof(ArgumentException))]
        public void SchoolShouldThrowException_WhenCreatingASchoolWithEmptyName()
        {
            var school = new School(string.Empty);
        }

        [TestMethod]
        [TestCategory("School")]
        [ExpectedException(typeof(ArgumentException))]
        public void SchoolShouldThrowException_WhenCreatingASchoolWithNull()
        {
            var school = new School(null);
        }

        [TestMethod]
        [TestCategory("School")]
        public void School_AddingCourseShouldIncreaseCount()
        {
            var school = new School("Test");
            school.AddCourse(new Course("IT"));
            school.AddCourse(new Course("Bulgarian"));
            school.AddCourse(new Course("English"));

            Assert.AreEqual(3, school.Courses.Count,"Adding of the course is succesfull");
        }

        [TestMethod]
        [TestCategory("School")]
        public void School_RemovingCourseShouldDecreaseCount()
        {
            var school = new School("Test");
            school.AddCourse(new Course("IT"));
            school.AddCourse(new Course("Bulgarian"));
            school.AddCourse(new Course("English"));

            var courseToRemove = school.Courses.FirstOrDefault(x => x.CourseName == "IT");
            school.RemoveCourse(courseToRemove);

            Assert.IsTrue(school.Courses.Count == 2);

        }

        [TestMethod]
        [TestCategory("School")]
        public void School_RemovingCourseSuccesfully()
        {
            var school = new School("Test");
            school.AddCourse(new Course("IT"));
            school.AddCourse(new Course("Bulgarian"));
            school.AddCourse(new Course("English"));

            var courseToRemove = school.Courses.FirstOrDefault(x => x.CourseName == "IT");
            school.RemoveCourse(courseToRemove);

            Assert.AreSame(courseToRemove.CourseName, "IT","Removing is succesfull");
        }

        [TestMethod]
        [TestCategory("School")]
        [ExpectedException(typeof(ArgumentException))]
        public void School_AddingSameCourseTwiseShouldThrowException()
        {
            var school = new School("Test");
            var course = new Course("IT");
            school.AddCourse(course);
            school.AddCourse(course);
        }

        [TestMethod]
        [TestCategory("School")]
        [ExpectedException(typeof(ArgumentException))]
        public void School_WillThrowException_WhenRemovingNotExistingCourse()
        {
            var school = new School("Test");
            school.AddCourse(new Course("Algebra"));
            school.AddCourse(new Course("Geometry"));

            var courseToRemove = new Course("Bulgarian");

            school.RemoveCourse(courseToRemove);
        }


        
        




    }
}
