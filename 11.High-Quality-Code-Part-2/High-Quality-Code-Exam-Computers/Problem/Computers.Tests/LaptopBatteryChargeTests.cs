namespace Computers.Tests
{
    using Logic;
    using NUnit.Framework;

    [TestFixture]
    public class LaptopBatteryChargeTests
    {
        [Test]
        public void BatteryPercentWillBeSixty_WhenChargeBatteryWith10Persents()
        {
            var battery = new LaptopBattery();
            var initChargeValue = battery.Percentage;

            battery.Charge(10);

            Assert.AreEqual(60, battery.Percentage);
        }

        [Test]
        public void BatteryPercentWillDecrease_WhenChargeBatteryWithMinus10Persents()
        {
            var battery = new LaptopBattery();
            var initChargeValue = battery.Percentage;
     
            battery.Charge(-10);

            Assert.AreEqual(40, battery.Percentage);
        }

        [Test]
        public void BatteryPercentCannotBeMoreThan100()
        {
            var battery = new LaptopBattery();
            var initChargeValue = battery.Percentage;

            battery.Charge(100);

            Assert.AreEqual(100, battery.Percentage);
        }

        [Test]
        public void BatteryPercentCannotBeLessThan0()
        {
            var battery = new LaptopBattery();
            var initChargeValue = battery.Percentage;

            battery.Charge(-100);

            Assert.AreEqual(0, battery.Percentage);
        }

        [Test]
        public void BatteryDefaultPercentageIs50_WhenNewBatteryIsCreated()
        {
            var battery = new LaptopBattery();

            Assert.AreEqual(50, battery.Percentage);
        }
    }
}
