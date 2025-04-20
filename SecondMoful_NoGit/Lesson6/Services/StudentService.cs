using Lesson6.DataAccess.Entities;
using Lesson6.Repostories;
using Lesson6.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson6.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepostory _studentRepostory;
        public StudentService()
        {
            _studentRepostory = new StudentRepostory();
        }
        public StudentGetDto AddStudent(StudentCreateDto dto)
        {
           var checkingEmail = _studentRepostory.CheckEmailContains(dto.Email);
            if (!dto.Email.EndsWith("@gmail.con") || checkingEmail)
            {
                return null;
            }
            var student = ConvertToStudentEntity(dto);
            var studentFromDb = _studentRepostory.WriteStudent(student);
            var studentDto = ConvertToDto(studentFromDb);
            return studentDto;
        }

        private Student ConvertToStudentEntity(StudentCreateDto dto)
        {
            throw new NotImplementedException();
        }

        public bool DeleteStudent(Guid id)
        {
            var result = _studentRepostory.RemoveStudent(id);
            return result;
        }

        public List<StudentGetDto> GetAllStudents()
        {
            var students = _studentRepostory.ReadAllStudents();
           var studentsGetDto = new List<StudentGetDto>();
            foreach (var student in students)
            {
                studentsGetDto.Add(ConvertToDto(student));
            }
            return studentsGetDto;
        }

        public StudentGetDto UpdateStudent(StudentUpdateDto studentUpdateDto)
        {

            var student = ConvertToStudentEntity(studentUpdateDto);
            var result = _studentRepostory.UpdateStudent(student);
            return (StudentGetDto)result;
        }

        private object ConvertToStudentEntity(StudentUpdateDto dto)
        {
            var student = new Student()
            {
                Id = Guid.NewGuid(),
                Email = dto.Email,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Age = dto.Age,
                Password = dto.Password,
            };
            return student;
        }

        
        private StudentGetDto ConvertToDto(Student student)
        {
            var dto = new StudentGetDto()
            {
                Id = student.Id,
                FirstName = student.FirstName,
                LastName = student.LastName,
                Age = student.Age,
                Email = student.Email,
            };
            return dto;
        }
    }
}
