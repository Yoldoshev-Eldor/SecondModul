using Lesson7.DataAccess.Entities;
using System.Text.Json;

namespace Lesson7.Repostories;

public class StudentRepostoriy : IStudentRepostory
{
    private readonly string _path;
    private List<Student> _students;
    public StudentRepostoriy()
    {
        _path = ".../../../DataAccess/Data/students.json";
        _students = new List<Student>();
        if (!File.Exists(_path))
        {
            File.WriteAllText(_path, "[]");

        }
        _students = ReadAllStudents();

    }
    public void EmailContains(string email)
    {
        throw new NotImplementedException();
    }

    public Student GetStudentById(Guid studentId)
    {
        foreach (var student in _students)
        {
            if (student.Id == studentId)
            {
                return student;
            }
        }
        throw new Exception("No such student found");
    }

    public List<Student> ReadAllStudents()
    {
        var studentJson = File.ReadAllText(_path);
        var studentsList = JsonSerializer.Deserialize<List<Student>>(studentJson);
        return studentsList;
    }

    public void RemoveStudent(Guid studentId)
    {
        var student = GetStudentById(studentId);
        _students.Remove(student);
        SaveData();

    }

    public void UpdateStudent(Student student)
    {
        var updatingStudent = GetStudentById(student.Id);
        var index = _students.IndexOf(updatingStudent);
        _students[index] = student;
        SaveData();
    }

    public Guid WriteStudent(Student student)
    {
       _students.Add(student);
        SaveData();
        return student.Id;
    }
    private void SaveData()
    {
        var studentJson = JsonSerializer.Serialize(_path);
        File.WriteAllText(_path, studentJson);
    }
}
