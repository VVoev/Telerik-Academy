using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasker.Core;
using Tasker.Core.Contracts;
using Tasker.Core.Providers;
using Tasker.Models.Contracts;
using Telerik.JustMock;

namespace Tasker.Tests
{
    [TestFixture]
    class TaskManagerTest
    {
        [Test]
        [Category("Tasker")]
        public void Add_ShouldLogSuccesfullyMessage_WhenPassedValidTask()
        {
            var loggerMock = Mock.Create<ILogger>();
            var idProviderMock = Mock.Create<IdProvider>();
            var taskMock = Mock.Create<ITask>();

            var manager = new TaskManager(idProviderMock, loggerMock);
            manager.Add(taskMock);

            Mock.Assert(() => loggerMock.Log(Arg.AnyString), Occurs.Once());
        }

        [Test]
        [Category("Tasker")]
        public void Remove_ShouldRemoveSuccesfully()
        {
            var loggerMock = Mock.Create<ILogger>();
            var idProviderMock = Mock.Create<IdProvider>();
            var firstTask = Mock.Create<ITask>();
            var secondTask = Mock.Create<ITask>();


            var manager = new TaskManager(idProviderMock, loggerMock);
            manager.Add(firstTask);
            manager.Add(secondTask);
            manager.Remove((int)(firstTask.Id));


            Assert.AreEqual(manager.Members().Count, 1);
        }

        [Test]
        [Category("Tasker")]
        public void AddesSuccesfullyFiveTask_WhenFiveTaskHasBeedAddedToManageR()
        {
            var loggerMock = Mock.Create<ILogger>();
            var idProviderMock = Mock.Create<IdProvider>();
            var manager = new TaskManager(idProviderMock, loggerMock);

            var task = Mock.Create<ITask>();
            var task1 = Mock.Create<ITask>();
            var task2 = Mock.Create<ITask>();
            var task3 = Mock.Create<ITask>();
            var task4 = Mock.Create<ITask>();

            manager.Add(task); manager.Add(task1); manager.Add(task2);manager.Add(task3);manager.Add(task4);

            Assert.AreEqual(manager.Members().Count, 5);
        }

       
    }
}
