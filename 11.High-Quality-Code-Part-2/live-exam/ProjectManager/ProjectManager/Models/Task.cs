using ProjectManager.Models.Contracts;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProjectManager.Models
{
    public class Task : ITask
    {
        public Task(string name, User owner, string state)
        {
            this.Name = name;
            this.Owner = owner;
            this.State = state;
        }

        [Required(ErrorMessage = "Task Name is required!")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Task Owner is required")]
        public User Owner { get; set; }

        public string State { get; set; }

        public override string ToString()
        {
            var builder = new StringBuilder();

            builder.AppendLine("    Name: " + this.Name);
            builder.AppendLine("    Owner: " + this.Owner.UserName);
            builder.Append("    State: " + this.State);

            return builder.ToString();
        }    
    }
}
