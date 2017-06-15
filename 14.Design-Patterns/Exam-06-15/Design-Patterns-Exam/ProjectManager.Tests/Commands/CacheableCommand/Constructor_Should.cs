using Moq;
using NUnit.Framework;
using ProjectManager.Framework.Core.Commands.Contracts;
using ProjectManager.Framework.Core.Commands.Decorators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.Tests.Commands.CacheableCommands
{
    [TestFixture]
    class Constructor_Should
    {
        [Test]
        public void ThrowErrorWhenCommand_WhenCommandIsProvidedButNoValueHasBeenAsigned()
        {
            //arange
            var command = new Mock<ICommand>();

            //Act && Assert
            Assert.Throws<ArgumentNullException>(() => new CacheableCommand(command.Object));
        }

        [Test]
        public void WillThrowError_WhenNullCommandIsProvided()
        {

            //Arange && Act && Assert
            Assert.Throws<ArgumentNullException>(() => new CacheableCommand(null));
        }

        [Test]
        public void CacheableCommandWillThrowException_BecauseIcommandIsNull()
        {
            //Arange
            var command = new Mock<ICommand>();
            //Act && Assert
            Assert.Throws<ArgumentNullException>(() => new CacheableCommand(command.Object));
        }
    }
}
