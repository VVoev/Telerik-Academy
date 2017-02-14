using IntergalacticTravel.Contracts;
using IntergalacticTravel.Exceptions;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace IntergalacticTravel.Tests.TeleportStationTests
{
    [TestFixture]
    public class TeleportStation_Should
    {
        
        [Test]
        public void Constructor_SetAllFields_WhenProvidedParameters_AreValid()
        {
            //Arrange
            var mockedOwner = new Mock<IBusinessOwner>();
            var mockedMap = new Mock<IEnumerable<IPath>>();
            var mockedLocation = new Mock<ILocation>();
            var expectedOwner = mockedOwner.Object;
            var expectedMap = mockedMap.Object;
            var expectedLocation = mockedLocation.Object;

            //Act
            var teleportStation = new ExtendedTeleportStation(mockedOwner.Object, mockedMap.Object, mockedLocation.Object);
            var owner = teleportStation.Owner;
            var map = teleportStation.GalacticMap;
            var location = teleportStation.Location;


            //Assert
            Assert.AreEqual(expectedOwner, owner);
            Assert.AreEqual(expectedMap, map);
            Assert.AreEqual(expectedLocation, location);
        }

        [Test]
        public void TeleportUnitThrowArgumentNullException_WhenUnitToTeleportIsNull()
        {
            //Arrange
            var mockedOwner = new Mock<IBusinessOwner>();
            var mockedMap = new Mock<IEnumerable<IPath>>();
            var mockedLocation = new Mock<ILocation>();
            var expectedOwner = mockedOwner.Object;
            var expectedMap = mockedMap.Object;
            var expectedLocation = mockedLocation.Object;

            //Act
            var teleportStation = new ExtendedTeleportStation(mockedOwner.Object, mockedMap.Object, mockedLocation.Object);
            var expetected = "unitToTeleport";

            //Assert
            var msg  = Assert.Throws<ArgumentNullException>(() => teleportStation.TeleportUnit(null, mockedLocation.Object));
            StringAssert.Contains(expetected, msg.Message);
        }

        [Test]
        public void TeleportUnitThrowArgumentNullException_WhenILocationIsNull()
        {
            //Arrange
            var mockedOwner = new Mock<IBusinessOwner>();
            var mockedMap = new Mock<IEnumerable<IPath>>();
            var mockedLocation = new Mock<ILocation>();
            var unitMock = new Mock<IUnit>();
            var expectedOwner = mockedOwner.Object;
            var expectedMap = mockedMap.Object;
            var expectedLocation = mockedLocation.Object;
            var expectedUnit = unitMock.Object;


            //Act
            var teleportStation = new ExtendedTeleportStation(mockedOwner.Object, mockedMap.Object, mockedLocation.Object);
            var expetected = "destination";

            //Assert
            var msg = Assert.Throws<ArgumentNullException>(() => teleportStation.TeleportUnit(expectedUnit, null));
            StringAssert.Contains(expetected, msg.Message);
        }

        [Test]
        public void ThrowTeleportOutOfRangeException_WhenUnitIsTryingToUseTheTeleportStationFromPlanetOrGalaxyDifferentThanThatOfTheStation()
        {
            var teleportStationLocationMock = new Mock<ILocation>();
            var teleportStationOwnerMock = new Mock<IBusinessOwner>();
            var teleportStationMapMock = new  Mock<IEnumerable<IPath>>();
            var targetLocationMock = new Mock<ILocation>();
            var unitToTeleportMock = new Mock<IUnit>();

            teleportStationLocationMock.Setup(x => x.Planet.Name).Returns("E1");
            teleportStationLocationMock.Setup(x => x.Planet.Galaxy.Name).Returns("G1");
            unitToTeleportMock.Setup(x => x.CurrentLocation.Planet.Name).Returns("R1");
            unitToTeleportMock.Setup(x => x.CurrentLocation.Planet.Galaxy.Name).Returns("R2");

            var teleportStation = new ExtendedTeleportStation(teleportStationOwnerMock.Object, teleportStationMapMock.Object, teleportStationLocationMock.Object);
            var expectedExceptionMessage = "unitToTeleport.CurrentLocation";

            //Act and Assert
            var exc = Assert.Throws<TeleportOutOfRangeException>(() => teleportStation.TeleportUnit(unitToTeleportMock.Object, targetLocationMock.Object));
            var actual = exc.Message;

            //Assert
            StringAssert.Contains(expectedExceptionMessage, actual);
        }
        [Test]
        public void InvalidTeleportationLocationException_WhenTryingToTeleportToAlreadyTakenLocation()
        {
            // Arrange
            var expectedExceptionMessage = "units will overlap";
            var planetName = "P1";
            var galaxyName = "G1";
            var longtitude = 45d;
            var latitude = 45d;

            var teleportStationLocationMock = new Mock<ILocation>();
            var teleportStationOwnerMock = new Mock<IBusinessOwner>();
            var targetLocationMock = new Mock<ILocation>();
            var unitToTeleportMock = new Mock<IUnit>();

            var planetaryUnitMock = new Mock<IUnit>();
            planetaryUnitMock.Setup(x => x.CurrentLocation.Planet.Name).Returns(planetName);
            planetaryUnitMock.Setup(x => x.CurrentLocation.Planet.Galaxy.Name).Returns(galaxyName);
            planetaryUnitMock.Setup(x => x.CurrentLocation.Coordinates.Latitude).Returns(latitude);
            planetaryUnitMock.Setup(x => x.CurrentLocation.Coordinates.Longtitude).Returns(longtitude);

            unitToTeleportMock.Setup(x => x.CurrentLocation.Planet.Name).Returns(planetName);
            unitToTeleportMock.Setup(x => x.CurrentLocation.Planet.Galaxy.Name).Returns(galaxyName);
            unitToTeleportMock.Setup(x => x.CurrentLocation.Coordinates.Latitude).Returns(latitude);
            unitToTeleportMock.Setup(x => x.CurrentLocation.Coordinates.Longtitude).Returns(longtitude);

            targetLocationMock.Setup(x => x.Planet.Name).Returns(planetName);
            targetLocationMock.Setup(x => x.Planet.Galaxy.Name).Returns(galaxyName);
            targetLocationMock.Setup(x => x.Coordinates.Latitude).Returns(latitude);
            targetLocationMock.Setup(x => x.Coordinates.Longtitude).Returns(longtitude);


            var pathMock = new Mock<IPath>();
            var teleportStationMapMock = new List<IPath> { pathMock.Object };
            var teleportStation = new ExtendedTeleportStation(teleportStationOwnerMock.Object, teleportStationMapMock, teleportStationLocationMock.Object);

            // Act & Assert
            Assert.Throws<InvalidTeleportationLocationException>(
                () => teleportStation.TeleportUnit(unitToTeleportMock.Object, targetLocationMock.Object));

        }



    }
}
