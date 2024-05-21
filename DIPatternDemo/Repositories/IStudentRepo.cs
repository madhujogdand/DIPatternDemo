using DIPatternDemo.Models;

namespace DIPatternDemo.Repositories
{
    public interface IStudentRepo
    {
        IEnumerable<Student> GetStudents();
        Student GetStudentById(int id);
        int AddStudent(Student student);
        int EditStudent(Student student);
        int DeleteStudent(int id);
    }
}
