using Exam_tasks.DataAccess.Entities;
using Exam_tasks.Services;
using Exam_tasks.Services.DTOs;

namespace Exam_tasks
{
    public class Program
    {
        static void Main(string[] args)
        {
            IUserService userService = new UserService();
           var user = new CreateDto();

            user.FirstName = "Test";
            user.LastName = "jjjjk";
            user.Email = "jhjhjj";
            user.Age = 30;
            user.Password = "dfddfs";

           var userrr = userService.AddUser(user);
        }
    }
}
