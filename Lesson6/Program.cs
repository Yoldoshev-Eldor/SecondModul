using Lesson6.Services;
using Lesson6.Services.DTOs;

namespace Lesson6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IStudentService studentService = new StudentService();
            StudentCreateDto dto = new StudentCreateDto()
            {
                FirstName = "Test",
                LastName = "Test",
                Age = 1,
                Password = "Test",
                Email = "aaaaaadddddaaa@gmail.com",
            }; 
            StudentCreateDto dto2 = new StudentCreateDto()
            {
                FirstName = "Qovun",
                LastName = "Test",
                Age = 1,
                Password = "Qovyun",
                Email = "aaaaaaaaaa@gmail.com",
            };

            studentService.AddStudent(dto);
            studentService.AddStudent(dto2);
            Console.WriteLine("ssssssss");

        }
    }
}
