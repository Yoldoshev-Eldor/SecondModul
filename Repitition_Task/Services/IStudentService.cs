using Repitition_Task.DataAccess.Entities;
using Repitition_Task.Services.DTOs;
using Repitition_Task.Services.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repitition_Task.Services;

public interface IStudentService 
{
    Guid AddStudent(StudentCreateDto student);
    void DeleteStudent(Guid studentId);
    void UpdateStudent(StudentUpdateDto student);
    List<StudentGetDto> GetStudents();

}
