using Academy.Commands.Adding;
using Academy.Core.Contracts;

namespace Academy.NewTests.Commands.Adding
{
    class AddStudentToSeasonCommandMock : AddStudentToSeasonCommand
    {
        public AddStudentToSeasonCommandMock(IAcademyFactory factory, IEngine engine) : base(factory, engine)
        {

        }

        public IAcademyFactory Factory
        {
            get
            {
                return this.factory;
            }
        }

        public IEngine Engine
        {
            get
            {
                return this.engine;
            }
        }
    }
}
