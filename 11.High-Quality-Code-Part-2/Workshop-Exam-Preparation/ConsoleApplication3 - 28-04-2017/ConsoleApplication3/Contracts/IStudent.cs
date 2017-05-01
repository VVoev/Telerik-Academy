namespace StudentApplication
{
    public interface IStudent
    {
        string FirstName { get; }

        string LastName { get; }

        Grade Grade { get; }
    }
}