using System.Text;

namespace GuardsDemo
{
    class Student
    {
        public int Age { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public override string ToString()
        {
            var builder = new StringBuilder();

            builder.AppendLine($"Name: {this.Name}");
            builder.AppendLine($"Email: {this.Email}");
            builder.AppendLine($"Age: {this.Age}");

            return builder.ToString();
           
        }
    }
}
