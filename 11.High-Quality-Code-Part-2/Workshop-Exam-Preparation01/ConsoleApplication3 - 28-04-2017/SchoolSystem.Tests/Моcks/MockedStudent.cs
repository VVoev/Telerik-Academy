using SchoolSystemCli.Models;
using SchoolSystemCli.Models.Enums;

namespace SchoolSystem.Tests.Моcks
{
    class MockedStudent : Student
    {
        public MockedStudent(string firstName, string lastName, Grade grade) : base(firstName, lastName, grade)
        {
        }
    }
}
