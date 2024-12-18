using Lesson7.DataAccess.Entities;

namespace Lesson7.Repostories
{
    public interface IStudentRepostory
    {
        Guid WriteStudent(Student student);
        List<Student> ReadAllStudents();
        void RemoveStudent(Guid studentId);
        Student GetStudentById(Guid studentId);
        void UpdateStudent(Student student);
        void EmailContains(string email);
    }
}