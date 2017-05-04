using ProjectManager.Core.Contacts;

namespace ProjectManager.Core
{
    public class EngineProvider : IEngineProvider
    {
        private Engine engine;

        public EngineProvider(Engine engine)
        {
            this.engine = engine;
        }

        public void Start()
        {
            this.engine.Start();
        }
    }
}
