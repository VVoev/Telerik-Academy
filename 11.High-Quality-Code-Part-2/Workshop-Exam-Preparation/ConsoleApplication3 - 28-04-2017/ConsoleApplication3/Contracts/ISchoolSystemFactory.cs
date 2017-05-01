namespace StudentApplication
{
    public interface ISchoolSystemFactory
    {
        IStudent CreateStudent(string firstName, string lastName, Grade grade);

        ITeacher CreateTeacher(string firstName, string lastName, Subject subject);
    }
}