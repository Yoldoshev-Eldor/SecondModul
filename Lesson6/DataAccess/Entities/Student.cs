namespace Lesson6.DataAccess.Entities
{
    public class Student
    {
        public Guid Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; } 
        public int Age { get; set; } 
        public string Password { get; set; }
        public string Email { get; set; }
    }
}
