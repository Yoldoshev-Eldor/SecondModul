using Lesson2_json_crud.Models;
using System.Text.Json;

namespace Lesson2_json_crud.Services
{
    public class TeacherService
    {
        private string teacherFile;
        private List<Teacher> _teachers;
        public TeacherService()
        {
            teacherFile = "../../../Data/Teacher.json";
            if(File.Exists(teacherFile) is false)
            {
                File.WriteAllText(teacherFile, "[]");
            }
            _teachers = new List<Teacher>();
            _teachers = GetAllTeacher();
        }
        public bool CheekLogin(string login, string password)
        {
            var loginMain = "director1";
            var passwordMain = "director1";
            if (login == loginMain &&  password == passwordMain)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public Teacher AddTeacher(Teacher newTeacher)
        {
            newTeacher.Id = Guid.NewGuid();
            _teachers.Add(newTeacher);
            SaveData();
            return newTeacher;
        }
        public bool DeleteTeacher(Guid id)
        { 
            var deleteTeacher = GetById(id);
            if (deleteTeacher is null)
            {
                return false;
            }
            _teachers.Remove(deleteTeacher);
            SaveData() ;
            return true;
        }
        public bool UpdateTeacher(Teacher teacher)
        {
            var result = GetById(teacher.Id);

            if (result is null)
            {
                return false;
            }
            var index = _teachers.IndexOf(teacher);
            _teachers[index] = teacher;
            SaveData();
            return true;
        }
        public Teacher GetById(Guid id)
        {
            foreach (var teacher in _teachers)
            {
                if (teacher.Id == id)
                {
                    return teacher;
                }
            }
            return null;
        }
        private void SaveData()
        {
            var studentJson = JsonSerializer.Serialize(_teachers);
            File.WriteAllText(teacherFile, studentJson);
        }
        private List<Teacher> GetTeachers()
        {
            var teacherJson = File.ReadAllText(teacherFile);
            var teacherList = JsonSerializer.Deserialize<List<Teacher>>(teacherJson);
            return teacherList;
        }
        public List<Teacher> GetAllTeacher()
        {
            return GetTeachers();
        }
    }
}
