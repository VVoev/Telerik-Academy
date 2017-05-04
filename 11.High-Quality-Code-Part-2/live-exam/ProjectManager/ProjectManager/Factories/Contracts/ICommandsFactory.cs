using ProjectManager.Contracts;

namespace ProjectManager.Factories.Contracts
{
    /// <summary>
    /// Describes how it create a comand from a given string
    /// </summary>
    public interface ICommandsFactory
    {
        /// <summary>
        /// Method which create a command from a given string
        /// </summary>
        /// <param name="commandName">String which require to convert to command</param>
        /// <returns></returns>
        ICommand CreateCommandFromString(string commandName);
    }
}
