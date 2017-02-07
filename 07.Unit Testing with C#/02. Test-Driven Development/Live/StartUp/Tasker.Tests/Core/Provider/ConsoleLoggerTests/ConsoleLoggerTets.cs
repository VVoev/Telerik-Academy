
using NUnit.Framework;
using System;
using System.IO;
using Tasker.Core.Providers;

namespace Tasker.Tests.Core.Provider
{
    [TestFixture]
    class ConsoleLoggerTets
    {
        [Category("Console")]
        [TestCase("Pesho")]
        [TestCase(null)]
        [TestCase("VeryLongStringjsakhskjashaklhsaklshaklshjaklshakl")]
        [Test]
        public void Log_ShouldLogToConsole_WhenInvoked(string value)
        {
            var message = value;
            var sut = new ConsoleLogger();

            var outputStream = new StringWriter();
            var defaultStream = Console.Out;
            Console.SetOut(outputStream);

            sut.Log(message);

            //Assert
            Assert.AreEqual(message+Environment.NewLine, outputStream.ToString());
        }
    }
}
