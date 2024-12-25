using Repitition_Task.DataAccess.Entities;
using Repitition_Task.Repostories;
using Repitition_Task.Services.DTOs;

namespace Repitition_Task.Services
{
    public class StudenteService : IStudentService
    {
        private readonly IStudntRepostory _studentRepo;
        public StudenteService()
        {
            _studentRepo = new StudentRepostory();
        }
        public Guid AddStudent(StudentCreateDto studentCreateDto)
        {
            _studentRepo.WriteStudent(ConvertToEntitiCreate(studentCreateDto));
            return ConvertToEntitiCreate(studentCreateDto).Id;

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
               
            };
        }

        public void DeleteStudent(Guid studentId)
        {
           _studentRepo.RemoveStudent(studentId);
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

        public void UpdateStudent(StudentUpdateDto student)
        {
            var updateStudent = ConvertToEntitiUpdate(studentUpdateDto);
            _studentRepo.UpdateStudent(updateStudent);
        }
    }
}
