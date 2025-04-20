using Lesson2_json_crud.Models;

namespace Lesson2_json_crud.Services
{
    public interface IStudentService
    {
        public bool CheekLogin(string login, string password);
        public Student AddStudent(Student student);
        public Student GetById(Guid studentId);
        public bool DeleteStudent(Guid studentId);
        public bool UpdateStudent(Student student);
        public List<Student> GetAllStudents();




    }
}