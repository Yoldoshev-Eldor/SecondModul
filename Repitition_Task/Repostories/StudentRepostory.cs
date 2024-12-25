using Repitition_Task.DataAccess.Entities;
using System.Text.Json;

namespace Repitition_Task.Repostories;

public class StudentRepostory : IStudntRepostory
{
    private readonly string _path;
    private List<Student> _students;
    public StudentRepostory()
    {
        _path = "../../../DataAccess/Data/Students.json";
        _students = new List<Student>();
        if (!File.Exists(_path))
        {
            File.WriteAllText(_path, "[]");

        }
        _students = ReadAllStudents();
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
        var students = JsonSerializer.Deserialize<List<Student>>(studentJson);
        return students;
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
        var studentJson = JsonSerializer.Serialize(_students);
        File.WriteAllText(_path, studentJson);
    }
}
