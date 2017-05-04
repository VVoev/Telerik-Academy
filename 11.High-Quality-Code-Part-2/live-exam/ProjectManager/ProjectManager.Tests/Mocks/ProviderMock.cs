using Moq;
using ProjectManager.Core;
using ProjectManager.Core.Contacts;

namespace ProjectManager.Tests.Mocks
{
    public class ProviderMock : EngineProvider
    {
        public ProviderMock(Engine engine) : base(engine)
        {
        }
    }
}
