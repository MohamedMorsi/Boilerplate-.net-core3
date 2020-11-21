using System;
using System.Collections.Generic;
using System.Linq;
using Boilerplate.Data.Contract;
using Boilerplate.Models;

namespace Boilerplate.Data.Repository
{
    public class StudentRepo : IStudentRepo
    {
        private readonly DataContext _ctx;

        public StudentRepo(DataContext ctx)
        {
            _ctx = ctx;
        }

        public void CreateStudent(Student s)
        {
            if(s == null){
                throw new ArgumentNullException(nameof(s));
            }
            _ctx.Students.Add(s);
        }

        public void DeleteStudent(Student s)
        {
             if(s == null){
                throw new ArgumentNullException(nameof(s));
            }
            _ctx.Students.Remove(s);
        }

        public IEnumerable<Student> GetAll()
        {
            return _ctx.Students.ToList();
        }

        public Student GetStudentById(int id)
        {
            return _ctx.Students.FirstOrDefault( s => s.Id == id);
        }

        public bool SaveChanges()
        {
           return (_ctx.SaveChanges() >=0);
        }

        public void UpdateStudent(Student s)
        {
            //nothing
        }
    }
}