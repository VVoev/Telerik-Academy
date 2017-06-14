using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Framework.Models.Contracts
{
    interface BundleInterfaces
    {
    }

    public interface IAddStudent
    {
        void AddStudent(int id, IStudent student);
    }

    public interface IAddTeacher
    {
        void AddTeacher(int id, ITeacher teacher);
    }

    public interface IRemoveStudent
    {
        void RemoveStudent(int id);
    }

    public interface IRemoveTeacher
    {
        void RemoveTeacher(int id);
    }

    public interface IGetStudent
    {
        IStudent GetStudent(int id);
    }

    public interface IGetTeacher
    {
        ITeacher GetTeacher(int id);
    }

    public interface IGetTeacherAndStudent : IGetStudent, IGetTeacher
    {
    }

    public interface ISchool : IAddStudent, IAddTeacher, IRemoveStudent, IRemoveTeacher, IGetTeacherAndStudent
    {
    }

}
