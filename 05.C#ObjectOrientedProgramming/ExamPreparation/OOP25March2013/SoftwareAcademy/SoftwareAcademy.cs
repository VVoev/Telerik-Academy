using System;
using System.Linq;
using System.Text;
using System.CodeDom.Compiler;
using Microsoft.CSharp;
using System.Reflection;
using System.Collections.Generic;

namespace SoftwareAcademy
{
    public interface ICourse
    {
        string Name { get; set; }
        ITeacher Teacher { get; set; }
        void AddTopic(string topic);
        string ToString();
    }
    public interface ICourseFactory
    {
        ITeacher CreateTeacher(string name);
        ILocalCourse CreateLocalCourse(string name, ITeacher teacher, string lab);
        IOffsiteCourse CreateOffsiteCourse(string name, ITeacher teacher, string town);
    }
    public interface ILocalCourse : ICourse
    {
        string Lab { get; set; }
    }
    public interface IOffsiteCourse : ICourse
    {
        string Town { get; set; }
    }
    public interface ITeacher
    {
        string Name { get; set; }
        void AddCourse(ICourse course);
        string ToString();
    }
    public abstract class Course : ICourse
    {
        private string name;
        private ITeacher teacher = new Teacher();
        private ICollection<string> topics = new List<string>();

        public Course(string name, ITeacher teacher)
        {
            this.Name = name;
            this.Teacher = teacher;
            this.Topics = topics;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("You must enter course name!");
                }
                this.name = value;
            }
        }

        public ITeacher Teacher
        {
            get
            {
                return this.teacher;
            }

            set
            {
                this.teacher = value;
            }
        }

        public ICollection<string> Topics
        {
            get
            {
                return new List<string>();
            }
            set
            {
                this.topics = value;
            }
        }

        public void AddTopic(string topic)
        {
            this.topics.Add(topic);
        }

        public override string ToString()
        {
            //(course type): Name=(course name); Teacher=(teacher name); Topics=[(course topics – comma separated)]; Lab=(lab name – when applicable); Town=(town name – when applicable);
            var sb = new StringBuilder();
            sb.Append(string.Format("Name={0}", this.Name));
            if (this.Teacher != null)
            {
                sb.Append(string.Format("; Teacher={0}", this.Teacher.Name));
            }
            if (this.topics.Count > 0)
            {
                sb.Append(string.Format("; Topics=[{0}]", string.Join(", ", this.topics)));
            }
            sb.AppendLine();
            return sb.ToString().TrimEnd();
        }
    }
    public class CourseFactory : ICourseFactory
    {
        public ITeacher CreateTeacher(string name)
        {
            return new Teacher(name);
        }

        public ILocalCourse CreateLocalCourse(string name, ITeacher teacher, string lab)
        {
            return new LocalCourse(name, teacher, lab);
        }

        public IOffsiteCourse CreateOffsiteCourse(string name, ITeacher teacher, string town)
        {
            return new OffsiteCourse(name, teacher, town);
        }
    }
    public class LocalCourse : Course, ILocalCourse
    {
        private string labName;

        public LocalCourse(string name, ITeacher teacher, string labName)
            : base(name, teacher)
        {
            this.Lab = labName;
        }

        public string Lab
        {
            get
            {
                return this.labName;
            }

            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Must enter lab name.");
                }
                this.labName = value;
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append(string.Format("{0}: ", this.GetType().Name));
            sb.Append(base.ToString());
            sb.AppendLine(string.Format(" Lab={0}", this.Lab));
            return sb.ToString().TrimEnd();
        }
    }
    public class OffsiteCourse : Course, IOffsiteCourse
    {
        private string townName;

        public OffsiteCourse(string name, ITeacher teacher, string labName)
            : base(name, teacher)
        {
            this.Town = labName;
        }

        public string Town
        {
            get
            {
                return this.townName;
            }

            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Must enter town name.");
                }
                this.townName = value;
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append(string.Format("{0}: ", this.GetType().Name));
            sb.Append(base.ToString());
            sb.AppendLine(string.Format(" Town={0}", this.Town));
            return sb.ToString().TrimEnd();
        }
    }
    public class Teacher : ITeacher
    {
        private string name;
        private ICollection<ICourse> teacherCourses;

        public Teacher()
        {

        }
        public Teacher(string name)
        {
            this.Name = name;
            this.TeacherCourses = new List<ICourse>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("You must enter a teacher name.");
                }
                this.name = value;
            }
        }

        public ICollection<ICourse> TeacherCourses
        {
            get
            {
                return this.teacherCourses = new List<ICourse>();
            }
            set
            {
                this.teacherCourses = value;
            }
        }

        public void AddCourse(ICourse course)
        {
            this.TeacherCourses.Add(course);
        }

        public override string ToString()
        {
            //Teacher: Name=(teacher name); Courses=[(course names – comma separated)]
            var sb = new StringBuilder();
            sb.Append(string.Format("Teacher: Name={0}; ", this.name));
            if (this.teacherCourses.Count > 0)
            {
                sb.Append(string.Format("Courses=["));
                foreach (var course in this.teacherCourses)
                {
                    sb.Append(course.Name + ",");
                }
                sb.Append("]; ");
            }
            sb.AppendLine();
            return sb.ToString().TrimEnd();
        }
    }
    public class SoftwareAcademyCommandExecutor
    {
        static void Main()
        {
            string csharpCode = ReadInputCSharpCode();
            CompileAndRun(csharpCode);
        }

        private static string ReadInputCSharpCode()
        {
            StringBuilder result = new StringBuilder();
            string line;
            while ((line = Console.ReadLine()) != "")
            {
                result.AppendLine(line);
            }
            return result.ToString();
        }

        static void CompileAndRun(string csharpCode)
        {
            // Prepare a C# program for compilation
            string[] csharpClass =
            {
                @"using System;
                  using SoftwareAcademy;

                  public class RuntimeCompiledClass
                  {
                     public static void Main()
                     {"
                        + csharpCode + @"
                     }
                  }"
            };

            // Compile the C# program
            CompilerParameters compilerParams = new CompilerParameters();
            compilerParams.GenerateInMemory = true;
            compilerParams.TempFiles = new TempFileCollection(".");
            compilerParams.ReferencedAssemblies.Add("System.dll");
            compilerParams.ReferencedAssemblies.Add(Assembly.GetExecutingAssembly().Location);
            CSharpCodeProvider csharpProvider = new CSharpCodeProvider();
            CompilerResults compile = csharpProvider.CompileAssemblyFromSource(
                compilerParams, csharpClass);

            // Check for compilation errors
            if (compile.Errors.HasErrors)
            {
                string errorMsg = "Compilation error: ";
                foreach (CompilerError ce in compile.Errors)
                {
                    errorMsg += "\r\n" + ce.ToString();
                }
                throw new Exception(errorMsg);
            }

            // Invoke the Main() method of the compiled class
            Assembly assembly = compile.CompiledAssembly;
            Module module = assembly.GetModules()[0];
            Type type = module.GetType("RuntimeCompiledClass");
            MethodInfo methInfo = type.GetMethod("Main");
            methInfo.Invoke(null, null);
        }
    }
}
