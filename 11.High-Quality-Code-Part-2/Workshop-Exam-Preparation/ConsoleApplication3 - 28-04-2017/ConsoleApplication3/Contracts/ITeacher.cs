namespace StudentApplication
{
    public interface ITeacher
    {
        string FirstName { get; }

        string LastName { get; }

        Subject Subject { get; }
    }
}