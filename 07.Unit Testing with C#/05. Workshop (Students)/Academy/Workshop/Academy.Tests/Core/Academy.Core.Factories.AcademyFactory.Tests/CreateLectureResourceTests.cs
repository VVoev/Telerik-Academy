using Academy.Core.Factories;
using Academy.Models.Utils.LectureResources;
using NUnit.Framework;
using System;

namespace Academy.Tests.Core.Academy.Core.Factories.AcademyFactorysss.Tests
{
    [TestFixture]
   public class CreateLectureResourceTests
    {
        [Category("Resources")]
        [Test]
        public void ShouldCreateVideoResource_WhenVideoResourceIsPassed()
        {
            //Arrange
            var factory = AcademyFactory.Instance;

            //Act
            var resource = factory.CreateLectureResource("video", "pesho", "www.abv.bg");

            //Assert
            Assert.IsInstanceOf<VideoResource>(resource);
        }
        [Category("Resources")]
        [Test]
        public void ShouldCreatePrsentationResource_WhenPresentantionResourceIsPassed()
        {
            //Arrange
            var factory = AcademyFactory.Instance;

            //Act
            var resource = factory.CreateLectureResource("presentation", "pesho", "abv.bg");

            //Assert
            Assert.IsInstanceOf<PresentationResource>(resource);
        }
        [Category("Resources")]
        [Test]
        public void ShouldCreateDemoResource_WhenDemoResourceIsPassed()
        {
            //Arrange
            var factory = AcademyFactory.Instance;

            //Act
            var resource = factory.CreateLectureResource("demo", "pesho", "abv.bg");

            //Assert
            Assert.IsInstanceOf<DemoResource>(resource);
        }
        [Category("Resources")]
        [Test]
        public void ShouldCreateHWResource_WhenHWResourceIsPassed()
        {
            //Arrange
            var factory = AcademyFactory.Instance;

            //Act
            var resource = factory.CreateLectureResource("homework", "pesho", "abv.bg");

            //Assert
            Assert.IsInstanceOf<HomeworkResource>(resource);
        }

        [Category("Resources")]
        [Test]
        public void ShouldThrowException_WhenInvalidResourceArePassed()
        {
            //Arrange
            var factory = AcademyFactory.Instance;

            //Act
            var resource = new [] { "WebContect", "pesho", "abv.bg" };

            //Assert
            Assert.Throws<ArgumentException>(() => factory.CreateLectureResource(resource[0],resource[1],resource[2]));
        }
    }
}
