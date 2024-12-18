using Lesson7.DataAccess.Enums;

namespace Lesson7.Services.DTOs;

public class BaseStudentDto
{
 
    public string LastName { get; set; }
    public string FirstName { get; set; }
    public int Age { get; set; }
    public string Email { get; set; }
  
    public Degree Degree { get; set; }
    public Gender Gender { get; set; }
}
