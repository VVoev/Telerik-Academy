namespace Computers.Tests
{
    using Logic;
    using Logic.Cpus;
    using Logic.VideoCards;
    using Moq;
    using NUnit.Framework;

    [TestFixture]
    class CpuSquareNumberTests
    {
        [Test]
        public void bla()
        {
            var cpu = new Cpu32(4,new Ram(4), new MonochromeVideoCard());
            var motherBoardMock = new Mock<IMotherboard>();

            motherBoardMock.Setup(x => x.LoadRamValue()).Returns(-15);
            cpu.SquareNumber();
            motherBoardMock.Verify(x => x.DrawOnVideoCard(It.Is<string>(para => para.Contains("23"))));
        }
    }
}
