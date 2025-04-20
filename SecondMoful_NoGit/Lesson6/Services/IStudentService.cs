using Lesson6.Services.DTOs;

namespace Lesson6.Services
{
    public interface IStudentService
    {
        StudentGetDto AddStudent(StudentCreateDto dto);
        bool DeleteStudent(Guid id);
        StudentGetDto UpdateStudent(StudentUpdateDto studentUpdateDto);
        List<StudentGetDto> GetAllStudents();

    }
}