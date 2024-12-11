using Lesson2_json_crud.Models;

namespace Lesson2_json_crud.Services
{
    public interface ITeacherService
    {
        public bool CheekLogin(string login, string password);
        public Teacher AddTeacher(Teacher newTeacher);
        public bool DeleteTeacher(Guid id);
        public bool UpdateTeacher(Teacher teacher);
        public Teacher GetById(Guid id);
        public List<Teacher> GetAllTeacher();

    }
}