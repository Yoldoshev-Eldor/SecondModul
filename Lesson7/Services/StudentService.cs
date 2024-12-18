using Lesson7.DataAccess.Entities;
using Lesson7.Repostories;
using Lesson7.Services.DTOs;
using Lesson7.Services.Enums;

namespace Lesson7.Services;

public class StudentService : IStudentService
{
    private readonly StudentRepostoriy _studentRepo;

    public StudentService()
    {
        _studentRepo = new StudentRepostoriy();
    }
    private Student ConvertToEntitiCreate(StudentCreateDto studentCreateDto)
    {
        return new Student
        {
            Id = Guid.NewGuid(),
            FirstName = studentCreateDto.FirstName,
            LastName = studentCreateDto.LastName,
            Age = studentCreateDto.Age,
            Email = studentCreateDto.Email,
            Password = studentCreateDto.Password,
            Degree = studentCreateDto.Degree,
            Gender = studentCreateDto.Gender,
        };
    }
    private Student ConvertToEntitiUpdate(StudentUpdateDto studentUpdateDto)
    {
        return new Student
        {
            Id = studentUpdateDto.Id,
            FirstName = studentUpdateDto.FirstName,
            LastName = studentUpdateDto.LastName,
            Age = studentUpdateDto.Age,
            Email = studentUpdateDto.Email,
            Password = studentUpdateDto.Password,
            Degree = studentUpdateDto.Degree,
            Gender = studentUpdateDto.Gender,
        };

    }
    private StudentGetDto ConvertToDto(Student student)
    {
        return new StudentGetDto
        {
            Id = student.Id,
            FirstName = student.FirstName,
            LastName = student.LastName,
            Age = student.Age,
            Email = student.Email,
            Degree = student.Degree,
            Gender = student.Gender,
        };
    }
    private bool ValidatStudentCreateDto(StudentCreateDto obj)
    {
        if (string.IsNullOrWhiteSpace(obj.FirstName) || obj.FirstName.Length > 50)
        {
            return false;
        }
        if (string.IsNullOrWhiteSpace(obj.LastName) || obj.LastName.Length > 50)
        {
            return false;
        }
        if (obj.Age < 15 || obj.Age > 55)
        {
            return false;
        }
        if (string.IsNullOrWhiteSpace(obj.Email) || !obj.Email.EndsWith("@gmail.com") || obj.Email.Length < 10 || obj.Email.Length > 80)
        {
            return false;
        }
        if (string.IsNullOrWhiteSpace(obj.Password) || obj.Password.Length > 7 || obj.Password.Length > 20)
        {
            return false;
        }
        return true;
    }
    public Guid AddStudent(StudentCreateDto studentCreateDto)
    {
        var result = ValidatStudentCreateDto(studentCreateDto);
        if (result is false)
        {
            throw new Exception("Validatsiyadan otmadi . . . ");
        }
        _studentRepo.WriteStudent(ConvertToEntitiCreate(studentCreateDto));
        return ConvertToEntitiCreate(studentCreateDto).Id;
    }

    public void DeleteStudent(Guid studentId)
    {
        _studentRepo.RemoveStudent(studentId);
    }

    public StudentGetDto GetStudentById(Guid studentId)
    {
        var result = _studentRepo.GetStudentById(studentId);
        var res = ConvertToDto(result);
        return res;
    }

    public List<StudentGetDto> GetStudents()
    {
        var list = new List<StudentGetDto>();
        var repoStudent = _studentRepo.ReadAllStudents();
        foreach (var student in repoStudent)
        {
            var res = ConvertToDto(student);
            list.Add(res);
        }
        return list;
    }

    public List<StudentGetDto> GetStudentsByDegree(DegreeDto degreeStatusDto)
    {

        var students = _studentRepo.ReadAllStudents();
        var studentsDto = new List<StudentGetDto>();
        foreach (var student in students)
        {
            if ((DegreeDto)student.Degree == degreeStatusDto)
            {
                studentsDto.Add(ConvertToDto(student));
            }
        }
        return studentsDto;

    }

    public List<StudentGetDto> GetStudentsByGender(GenderDto genderDto)
    {
        var students = _studentRepo.ReadAllStudents();
        var studentsDto = new List<StudentGetDto>();
        foreach (var student in students)
        {
            if ((GenderDto)student.Degree == genderDto)
            {
                studentsDto.Add(ConvertToDto(student));
            }
        }
        return studentsDto;
    }

    public void UpdateStudent(StudentUpdateDto studentUpdateDto)
    {
        var updateStudent = ConvertToEntitiUpdate(studentUpdateDto);
        _studentRepo.UpdateStudent(updateStudent);
    }
}
