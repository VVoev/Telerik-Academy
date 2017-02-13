using Academy.Commands.Adding;
using Academy.Core.Contracts;

namespace Academy.Tests.Commands.AddStudentToSeasonCommandTests.Mock
{
    internal class AddStudentToSeasonMock : AddStudentToSeasonCommand
    {
        public AddStudentToSeasonMock(IAcademyFactory factory, IEngine engine) : base(factory, engine)
        {

        }

        public IAcademyFactory AcademyFactory
        {
            get { return this.factory; }
        }
        public IEngine Engine
        {
            get { return this.engine; }
        }
    }
}
