using Academy.Models.Abstractions;

namespace Academy.NewTests.Models.Abstractions.UserTests
{
    internal class UserMock : User
    {
        public UserMock(string username) : base(username)
        {
        }
    }
}
