namespace ProjectManager.Framework.Data.Models
{
    public interface IUser
    {
        string Email { get; set; }
        string Username { get; set; }

        string ToString();
    }
}