using ProjectManager.Commands;
using ProjectManager.Common;

namespace ProjectManager
{
    using Core;
    using Factories;
    using ProjectManager.Data;
    using ProjectManager.Models;

    public class Startup
    {
        public static void Main()
        {
            var engine = new Engine(new FileLogger(), new CmdCPU(new CommandsFactory(new Database(), new ModelsFactory())));
            var provider = new EngineProvider(engine);
            provider.Start();
        }
    }
}
