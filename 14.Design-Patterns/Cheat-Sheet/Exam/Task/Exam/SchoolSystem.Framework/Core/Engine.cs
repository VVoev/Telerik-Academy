using System;
using System.Collections.Generic;

using SchoolSystem.Framework.Core.Contracts;
using SchoolSystem.Framework.Models.Contracts;


namespace SchoolSystem.Framework.Core
{
    public interface IAddStudent
    {
        void AddStudent(int id, IStudent student);
    }
    public interface IRemoveStudent
    {
        void RemoveStudent(int id);
    }
    public interface IGetStudent
    {
        IStudent GetStudent(int id);
    }
    public interface IAddTeacher
    {
        void AddTeacher(int id, ITeacher teacher);
    }
    public interface IRemoveTeacher
    {
        void RemoveTeacher(int id);
    }
    public interface IGetTeacher
    {
        ITeacher GetTeacher(int id);
    }
    public interface IGetStudentAndTeacher : IGetStudent, IGetTeacher
    {
    }
    public interface ISchool : IAddStudent, IRemoveStudent, IAddTeacher, IRemoveTeacher, IGetTeacher, IGetStudent, IGetStudentAndTeacher
    {
    }

    public class School : ISchool
    {
        private readonly IDictionary<int, ITeacher> teachers;
        private readonly IDictionary<int, IStudent> students;

        public School()
        {
            this.teachers = new Dictionary<int, ITeacher>();
            this.students = new Dictionary<int, IStudent>();
        }

        public void AddStudent(int id, IStudent student)
        {
            this.students.Add(id, student);
        }

        public void RemoveStudent(int id)
        {
            this.students.Remove(id);
        }

        public void AddTeacher(int id, ITeacher teacher)
        {
            this.teachers.Add(id, teacher);
        }

        public void RemoveTeacher(int id)
        {
            if (!this.teachers.ContainsKey(id))
            {
                throw new ArgumentNullException("Command cannot be null or empty.");
            }
            this.teachers.Remove(id);
        }

        public IStudent GetStudent(int id)
        {
            return this.students[id];
        }

        public ITeacher GetTeacher(int id)
        {
            return this.teachers[id];
        }
    }

    public class Engine : IEngine
    {
        private const string TerminationCommand = "End";
        private const string NullProvidersExceptionMessage = "cannot be null.";

        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly IParser parser;

        /* Could also extract Database provider for Teachers and Students collections
           But it will become too complex for the purposes of this exam */

        public Engine(IReader readerProvider, IWriter writerProvider, IParser parserProvider)
        {
            if (readerProvider == null)
            {
                throw new ArgumentNullException($"Reader {NullProvidersExceptionMessage}");
            }

            if (writerProvider == null)
            {
                throw new ArgumentNullException($"Writer {NullProvidersExceptionMessage}");
            }

            if (parserProvider == null)
            {
                throw new ArgumentNullException($"Parser {NullProvidersExceptionMessage}");
            }

            this.reader = readerProvider;
            this.writer = writerProvider;
            this.parser = parserProvider;


        }


        public void Start()
        {
            while (true)
            {
                try
                {
                    var commandAsString = this.reader.ReadLine();

                    if (commandAsString == TerminationCommand)
                    {
                        break;
                    }

                    this.ProcessCommand(commandAsString);
                }
                catch (Exception ex)
                {
                    this.writer.WriteLine(ex.Message);
                }
            }
        }

        private void ProcessCommand(string commandAsString)
        {
            if (string.IsNullOrWhiteSpace(commandAsString))
            {
                throw new ArgumentNullException("Command cannot be null or empty.");
            }

            var command = this.parser.ParseCommand(commandAsString);
            var parameters = this.parser.ParseParameters(commandAsString);

            var executionResult = command.Execute(parameters);
            this.writer.WriteLine(executionResult);
        }
    }
}
