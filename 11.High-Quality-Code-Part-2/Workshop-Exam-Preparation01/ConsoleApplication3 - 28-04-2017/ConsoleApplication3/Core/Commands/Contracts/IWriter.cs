namespace SchoolSystem.CLI.Core.Commands.Contracts
{
    public interface IWriter
    {
        void Write(string msg);

        void WriteLine(string msg);
    }
}
