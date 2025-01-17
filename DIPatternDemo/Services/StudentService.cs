﻿using DIPatternDemo.Models;
using DIPatternDemo.Repositories;

namespace DIPatternDemo.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepo repo;
        public StudentService(IStudentRepo repo)
        {
            this.repo = repo;
        }
        public int AddStudent(Student student)
        {
            return repo.AddStudent(student);
        }

        public int DeleteStudent(int id)
        {
            return repo.DeleteStudent(id);
        }

        public int EditStudent(Student student)
        {
            return repo.EditStudent(student);
        }

        public Student GetStudentById(int id)
        {
            return repo.GetStudentById(id);
        }

        public IEnumerable<Student> GetStudents()
        {
            return repo.GetStudents();
        }
    }
}
