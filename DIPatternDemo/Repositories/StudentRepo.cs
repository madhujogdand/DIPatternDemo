using DIPatternDemo.Data;
using DIPatternDemo.Models;

namespace DIPatternDemo.Repositories
{
    public class StudentRepo : IStudentRepo
    {
        private readonly ApplicationDbContext db;

        public StudentRepo(ApplicationDbContext db)
        {
              this.db = db;
        }
        public int AddStudent(Student student)
        {
            student.IsActive = 1;
            int result = 0;
            db.Students.Add(student);
            result = db.SaveChanges();
            return result;
        }

        public int DeleteStudent(int rollno)
        {
            int result = 0;
            var model = db.Students.Where(stud => stud.RollNo == rollno).FirstOrDefault();
            if (model != null)
            {
                model.IsActive = 0;
                result = db.SaveChanges();
            }
            return result;
        }

        public int EditStudent(Student student)
        {
            int result = 0;
            var model = db.Students.Where(stud => stud.RollNo == student.RollNo).FirstOrDefault();
            if (model != null)
            {
                model.Name = student.Name;
                model.Course = student.Course;
                model.Fees = student.Fees;
                model.IsActive = 1;
                result = db.SaveChanges();
            }
            return result;
        }

        public Student GetStudentById(int rollno)
        {
            return db.Students.Where(x => x.RollNo == rollno).SingleOrDefault();
        }

        public IEnumerable<Student> GetStudents()
        {
            var model = (from stud in db.Students
                         where stud.IsActive == 1
                         select stud).ToList();
            return model;
        }
    }
}
