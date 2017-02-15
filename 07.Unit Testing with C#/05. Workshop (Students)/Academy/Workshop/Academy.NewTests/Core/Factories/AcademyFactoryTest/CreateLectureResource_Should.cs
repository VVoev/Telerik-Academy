using Academy.Core.Factories;
using Academy.Models.Contracts;
using Academy.Models.Utils.LectureResources;
using NUnit.Framework;
using System;

namespace Academy.NewTests.Core.Factories.AcademyFactoryTest
{
    [TestFixture]
    public class CreateLectureResource_Should
    {
        [Test]
        public void CreateLectureResourceShouldThrowArgumentException_WhenPassedTypeIsInvalid()
        {
            //Arrange
            var factory = AcademyFactory.Instance;
            //Act && Assert
            var res =Assert.Throws<ArgumentException>(() => factory.CreateLectureResource("Online", "C++", "PluralSight.com"));
            StringAssert.Contains("Invalid lecture", res.Message);
        }
        [TestCase("video")]
        [TestCase("presentation")]
        [TestCase("demo")]
        [TestCase("homework")]
        public void CreateLectureResourceShouldReturnCorrectInstanceWithCorrectlyAssignedData_WhenPassedTypeIsValid(string type)
        {
            //Arrange
            var factory = AcademyFactory.Instance;

            //Act
            var result = factory.CreateLectureResource(type, "C++", "PluralSight.com");


            //Assert
            switch (type)
            {
                case "video":Assert.IsInstanceOf<VideoResource>(result);break;
                case "presentation": Assert.IsInstanceOf<PresentationResource>(result);break;
                case "demo": Assert.IsInstanceOf<DemoResource>(result);break;
                case "homework": Assert.IsInstanceOf<HomeworkResource>(result);break;
                default: 
                    break;
            }


        }
    }
}
