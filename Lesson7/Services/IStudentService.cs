using Lesson7.Services.DTOs;
using Lesson7.Services.Enums;

namespace Lesson7.Services;

public interface IStudentService
{
    Guid AddStudent(StudentCreateDto studentCreateDto);
    void DeleteStudent(Guid studentId);
    StudentGetDto GetStudentById(Guid studentId);
    List<StudentGetDto> GetStudents();
    void UpdateStudent(StudentUpdateDto studentUpdateDto);
    List<StudentGetDto> GetStudentsByDegree(DegreeDto degreeStatusDto);
    List<StudentGetDto> GetStudentsByGender(GenderDto genderDto);
}