using Lesson2_json_crud.Models;
using System.Text.Json;

namespace Lesson2_json_crud.Services
{
    public class TeacherService
    {
        private string teacherFile;
        public TeacherService()
        {
            teacherFile = "../../../Data/Teacher.json";
            if(File.Exists(teacherFile) is false)
            {
                File.WriteAllText(teacherFile, "[]");
            }
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
            var teacherList = GetTeachers();
            teacherList.Add(newTeacher);
            SaveData(teacherList);
            return newTeacher;
        }
        public bool DeleteTeacher(Guid id)
        {
            var teacherList = GetTeachers();    
            var deleteTeacher = GetById(id);
            if (deleteTeacher is null)
            {
                return false;
            }
            teacherList.Remove(deleteTeacher);
            SaveData(teacherList) ;
            return true;
        }
        public bool UpdateTeacher(Teacher teacher)
        {
            var result = GetById(teacher.Id);
            var teacherList = GetTeachers();
            if (result is null)
            {
                return false;
            }
            var index = teacherList.IndexOf(teacher);
            teacherList[index] = teacher;
            SaveData(teacherList) ;
            return true;
        }
        public Teacher GetById(Guid id)
        {
            var teacherList = GetTeachers();
            foreach (var teacher in teacherList)
            {
                if (teacher.Id == id)
                {
                    return teacher;
                }
            }
            return null;
        }
        private void SaveData(List<Teacher> teachers)
        {
            var studentJson = JsonSerializer.Serialize(teachers);
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
