namespace SchoolSystem.CLI.Models.Contracts
{
    /// <summary>
    /// Represent a person with basic atributes first and last name
    /// </summary>
    public interface IPerson
    {
        string FirstName { get; }

        string LastName { get; }
    }
}
