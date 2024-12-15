using Lesson6.DataAccess.Entities;

namespace Lesson6.Repostories
{
    public interface IStudentRepostory
    {
        Student WriteStudent(Student student);
        bool RemoveStudent(Guid id);
        bool UpdateStudent(Student student);
        Student ReadByStudentId (Guid id);
        List<Student> ReadAllStudents();
        bool CheckEmailContains(string email);
        object UpdateStudent(object student);
    }
}