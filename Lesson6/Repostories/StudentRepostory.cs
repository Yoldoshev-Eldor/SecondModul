using Lesson6.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Lesson6.Repostories
{
    public class StudentRepostory : IStudentRepostory

    {
        private string path;
        private List<Student> _students;
        public StudentRepostory()
        {
            path = "../../../DataAccess/Data/Student.json";
            _students = new List<Student>();

            if (!File.Exists(path))
            {
                File.WriteAllText(path, "[]");
            }
            else
            {
                _students = ReadAllStudents();
            }

        }
        public bool CheckEmailContains(string email)
        {
            var students = _students;
            foreach (var student in students)
            {

                if (student.Email == email)
                {
                    return true;
                }
            }
            return false;
        }
        public List<Student> ReadAllStudents()
        {
            var studentsJson = File.ReadAllText(path);
            var students = JsonSerializer.Deserialize<List<Student>>(studentsJson);
            return students;
        }

        public Student ReadByStudentId(Guid id)
        {
          foreach (var student in _students)
            {
                if (student.Id == id)
                {
                    return student;
                }
            }
            return null;
        }

        public bool RemoveStudent(Guid id)
        {
            var removingStudent = ReadByStudentId(id);
            if (removingStudent == null)
            {
                return false;
            }
            _students.Remove(removingStudent);
            SaveData();
            return true;
        }

        public bool UpdateStudent(Student student)
        {
           var updatingStudent = ReadByStudentId(student.Id);
            if (updatingStudent == null)
            {
                return false;
            }
            var index = _students.IndexOf(student);
            _students[index] = student;
            SaveData();
            return true;
        }

        public object UpdateStudent(object student)
        {
            throw new NotImplementedException();
        }

        public Student WriteStudent(Student student)
        {
            throw new NotImplementedException();
        }
        private void SaveData()
        {
            var jsonData = JsonSerializer.Serialize(_students);
            File.WriteAllText(jsonData, path);
        }

    }
}
