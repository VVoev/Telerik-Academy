namespace SchoolSystem.Cli.Core.Providers.Contracts
{
    public interface IWriter
    {
        void Write(string msg);

        void WriteLine(string msg);
    }
}
