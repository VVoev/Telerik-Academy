using ProjectManager.Models.Contracts;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProjectManager.Models
{
    public class User : IUser
    {
        public User(string email, string username)
        {
            this.UserName = username;
            this.Email = email;
        }

        [Required(ErrorMessage = "User Username is required!")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "User Email is required!")]
        [EmailAddress(ErrorMessage = "User Email is not valid!")]
        public string Email { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine("    Username: " + this.UserName);
            sb.AppendLine("    Email: " + this.Email);
            return sb.ToString();
        }
    }
}
