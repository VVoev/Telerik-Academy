namespace Computers.Tests
{
    using Logic;
    using NUnit.Framework;

    [TestFixture]
    public class LaptopBatteryChargeTests
    {
        [Test]
        public void TestMethod1()
        {
            var battery = new LaptopBattery();
            var initChargeValue = battery.Percentage;
        }
    }
}
