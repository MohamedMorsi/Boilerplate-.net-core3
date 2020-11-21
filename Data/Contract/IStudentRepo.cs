using System.Collections.Generic;
using Boilerplate.Models;

namespace Boilerplate.Data.Contract
{
    public interface IStudentRepo
    {
        bool SaveChanges();
        IEnumerable<Student> GetAll ();
        Student GetStudentById(int id);
        void CreateStudent(Student s );
        void UpdateStudent(Student s );
        void DeleteStudent(Student s);

    }
}