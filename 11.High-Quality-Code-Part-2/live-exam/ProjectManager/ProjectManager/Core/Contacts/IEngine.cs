namespace ProjectManager.Core.Contacts
{
    /// <summary>
    /// Describes information about running application.
    /// </summary>
    public interface IEngine
    {
        /// <summary>
        /// Method which proceeds all commands in application.
        /// </summary>
        void Start();
    }
}
