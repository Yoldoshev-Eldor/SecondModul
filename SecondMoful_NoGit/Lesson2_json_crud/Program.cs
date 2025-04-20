using Lesson2_json_crud.Models;
using Lesson2_json_crud.Services;

namespace Lesson2_json_crud
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StartFrontend();
        }
        public static void StartFrontend()
        {
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine(" < < < < < < < < < < W E L C O M E  S CH O O L  W E B S I T E > > > > > > > > > ");
                Console.WriteLine();
                Console.WriteLine(" 1 .  I'm a Director ");
                Console.WriteLine(" 2 .  I'm a Teacher ");
                Console.WriteLine(" 3 .  I'm a Student ");
                Console.Write("Choose a section : ");
                var option = int.Parse(Console.ReadLine());
                if (option == 1)
                {
                    Console.Clear();
                    DirectorMenu();
                }
                else if (option == 2)
                {
                    Console.Clear();
                    TeacherMenu();
                }
                else if (option == 3)
                {
                    Console.Clear();
                    StudentMenu();
                }

            }
        }
        public static void DirectorMenu()
        {

            ITeacherService directorService = new TeacherService();
            while (true)
            {
                Console.Write("Enter Login : ");
                var login = Console.ReadLine();
                Console.Write("Enter Password : ");
                var password = Console.ReadLine();
                var cheek = directorService.CheekLogin(login, password);
                if (cheek is true)
                {
                    while (true)
                    {
                        Console.WriteLine("1. Add Teacher : ");
                        Console.WriteLine("2. Delete Teacher : ");
                        Console.WriteLine("3. Update Teacher : ");
                        Console.WriteLine("4. Get By Id : ");
                        Console.WriteLine("5. Get All Teacher : ");
                        Console.Write("ch o o s e ==> : ");
                        var option = int.Parse(Console.ReadLine());
                        if (option == 1)
                        {
                            var teacher = new Teacher();
                            Console.Write("Enter First Name : ");
                            teacher.FirstName = Console.ReadLine();
                            Console.Write("Enter Last Name : ");
                            teacher.LastName = Console.ReadLine();
                            Console.Write("Enter Age : ");
                            teacher.Age = int.Parse(Console.ReadLine());
                            Console.Write("Enter Subject : ");
                            teacher.Subject = Console.ReadLine();
                            Console.Write("Enter Likes : ");
                            teacher.Likes = int.Parse(Console.ReadLine());
                            Console.Write("Enter Dis Likes : ");
                            teacher.DisLikes = int.Parse(Console.ReadLine());
                            Console.Write("Enter Gender : ");
                            teacher.Gender = Console.ReadLine();
                            directorService.AddTeacher(teacher);
                            Console.WriteLine("Succesfully . . . ");

                        }
                        else if (option == 2)
                        {
                            Console.Write("Enter Guid : ");
                            var id = Guid.Parse(Console.ReadLine());
                            var deleteTeacher = directorService.DeleteTeacher(id);
                            if (deleteTeacher is true)
                            {
                                Console.WriteLine("Deleted . . . ");
                            }
                            else
                            {
                                Console.WriteLine(" E R R O R . . . ");
                            }
                        }
                        else if (option == 3)
                        {
                            var teacher = new Teacher();
                            Console.Write("Enter Id : ");
                            teacher.Id = Guid.Parse(Console.ReadLine());
                            Console.Write("Enter First Name : ");
                            teacher.FirstName = Console.ReadLine();
                            Console.Write("Enter Last Name : ");
                            teacher.LastName = Console.ReadLine();
                            Console.Write("Enter Age : ");
                            teacher.Age = int.Parse(Console.ReadLine());
                            Console.Write("Enter Subject : ");
                            teacher.Subject = Console.ReadLine();
                            Console.Write("Enter Likes : ");
                            teacher.Likes = int.Parse(Console.ReadLine());
                            Console.Write("Enter Dis Likes : ");
                            teacher.DisLikes = int.Parse(Console.ReadLine());
                            Console.Write("Enter Gender : ");
                            teacher.Gender = Console.ReadLine();
                            var updateTeacher = directorService.UpdateTeacher(teacher);
                            if (updateTeacher is true)
                            {
                                Console.WriteLine("Updated . . . ");
                            }
                            else
                            {
                                Console.WriteLine("Error . . . ");
                            }
                        }
                        else if (option == 4)
                        {
                            Console.Write("Enter Id : ");
                            var id = Guid.Parse(Console.ReadLine());
                            var GetId = directorService.GetById(id);
                            if (GetId is null)
                            {
                                Console.WriteLine("Error . . . ");
                            }
                            Console.WriteLine($"Id :        {GetId.Id}");
                            Console.WriteLine($"LastName :  {GetId.LastName}");
                            Console.WriteLine($"Firstname : {GetId.FirstName}");
                            Console.WriteLine($"Age :       {GetId.Age}");
                            Console.WriteLine($"Likes :     {GetId.Likes}");
                            Console.WriteLine($"Dis Likes : {GetId.DisLikes}");
                            Console.WriteLine($"Subject :   {GetId.Subject}");
                            Console.WriteLine($"Gender :    {GetId.Gender}");

                        }
                        else if (option == 5)
                        {
                            var teachers = directorService.GetAllTeacher();
                            foreach (var teacher in teachers)
                            {
                                Console.WriteLine($"Id :        {teacher.Id}");
                                Console.WriteLine($"LastName :  {teacher.LastName}");
                                Console.WriteLine($"Firstname : {teacher.FirstName}");
                                Console.WriteLine($"Age :       {teacher.Age}");
                                Console.WriteLine($"Likes :     {teacher.Likes}");
                                Console.WriteLine($"Dis Likes : {teacher.DisLikes}");
                                Console.WriteLine($"Subject :   {teacher.Subject}");
                                Console.WriteLine($"Gender :    {teacher.Gender}");
                            }
                        }
                        Console.ReadKey();
                        Console.Clear();
                    }
                }
                else
                {
                    Console.WriteLine("  E R R O R ");
                }
            }
        }
        public static void TeacherMenu()
        {
            IStudentService teacherService = new StudentService();
            while (true)
            {
                Console.Write("Enter Login : ");
                var login = Console.ReadLine();
                Console.Write("Enter Password : ");
                var password = Console.ReadLine();
                var cheek = teacherService.CheekLogin(login, password);


                if (cheek is true)
                {
                    while (true)
                    {
                        ITestService testService = new TestService();
                        IStudentService studentService = new StudentService();
                        Console.WriteLine("1. Add Student : ");
                        Console.WriteLine("2. Delete Student : ");
                        Console.WriteLine("3. Update Student : ");
                        Console.WriteLine("4. Get By Id student : ");
                        Console.WriteLine("5. Get All Student : ");
                        Console.WriteLine("6. Add Test : ");
                        Console.WriteLine("7. Delete  Test : ");
                        Console.WriteLine("8. Update Test : ");
                        Console.WriteLine("9. Get By Id Test : ");
                        Console.WriteLine("10. Get All Test : ");
                        Console.WriteLine("11. Get Random Tests : ");
                        Console.Write("ch o o s e ==> : ");
                        var option = int.Parse(Console.ReadLine());
                        if (option == 1)
                        {
                            var student = new Student();
                            Console.Write("Enter Last name : ");
                            student.LastName = Console.ReadLine();
                            Console.Write("Enter First name : ");
                            student.FirstName = Console.ReadLine();
                            Console.Write("Enter Age : ");
                            student.Age = int.Parse(Console.ReadLine());
                            Console.Write("Enter Degree : ");
                            student.Degree = Console.ReadLine();
                            Console.Write("Enter Gender : ");
                            student.Gender = Console.ReadLine();
                            Console.Write("Enter Result : ");
                            var result = int.Parse(Console.ReadLine());
                            student.Results.Add(result);
                            studentService.AddStudent(student);
                            Console.WriteLine("Added . . . ");


                        }
                        else if (option == 2)
                        {
                            var id = Guid.Parse(Console.ReadLine());
                            var result = studentService.DeleteStudent(id);
                            if (result is true)
                            {
                                Console.WriteLine("Deleted . . . ");
                            }
                            else
                            {
                                Console.WriteLine("Error . . . ");
                            }
                        }
                        else if (option == 3)
                        {
                            var student = new Student();
                            Console.Write("Enter Guid : ");
                            student.Id = Guid.Parse(Console.ReadLine());
                            Console.Write("Enter Last name : ");
                            student.LastName = Console.ReadLine();
                            Console.Write("Enter First name : ");
                            student.FirstName = Console.ReadLine();
                            Console.Write("Enter Age : ");
                            student.Age = int.Parse(Console.ReadLine());
                            Console.Write("Enter Degree : ");
                            student.Degree = Console.ReadLine();
                            Console.Write("Enter Gender : ");
                            student.Gender = Console.ReadLine();
                            Console.Write("Enter Result : ");
                            var result = int.Parse(Console.ReadLine());
                            student.Results.Add(result);
                            var updateStudent = studentService.UpdateStudent(student);
                            if (updateStudent is true)
                            {
                                Console.WriteLine("Updated . . . ");

                            }

                            else
                            {
                                Console.WriteLine("error . . . ");
                            }
                        }
                        else if (option == 4)
                        {

                            Console.Write("Enter id :");
                            var id = Guid.Parse(Console.ReadLine());
                            var student = studentService.GetById(id);
                            Console.WriteLine($"id :          {student.Id}");
                            Console.WriteLine($"First Name  : {student.FirstName}");
                            Console.WriteLine($"Last Name  :  {student.LastName}");
                            Console.WriteLine($"Age   :       {student.Age}");
                            Console.WriteLine($"Gender   :    {student.Gender}");
                            Console.WriteLine($"Degree   :    {student.Degree}");
                            Console.WriteLine();
                        }
                        else if (option == 5)
                        {
                            var students = studentService.GetAllStudents();
                            foreach (var student in students)
                            {
                                Console.WriteLine($"id :          {student.Id}");
                                Console.WriteLine($"First Name  : {student.FirstName}");
                                Console.WriteLine($"Last Name  :  {student.LastName}");
                                Console.WriteLine($"Age   :       {student.Age}");
                                Console.WriteLine($"Gender   :    {student.Gender}");
                                Console.WriteLine($"Degree   :    {student.Degree}");
                                Console.WriteLine();
                            }
                        }
                        else if (option == 6)
                        {
                            var test = new Test();
                            Console.Write("Question text :");
                            test.QuestionText = Console.ReadLine();

                            Console.Write("A variant :");
                            test.AVariant = Console.ReadLine();

                            Console.Write("B variant :");
                            test.BVariant = Console.ReadLine();

                            Console.Write("C variant :");
                            test.CVariant = Console.ReadLine();

                            Console.Write("Answer A/B/C :");
                            test.Answer = Console.ReadLine();

                            testService.AddTest(test);
                        }
                        else if (option == 7)
                        {
                            Console.Write("Enter id :");
                            var id = Guid.Parse(Console.ReadLine());
                            var result = testService.DeleteTest(id);
                            if (result == true)
                            {
                                Console.WriteLine("Succesfully . . . ");
                            }
                            else
                            {
                                Console.WriteLine("Error . . . ");
                            }
                        }
                        else if (option == 8)
                        {
                            var test = new Test();

                            Console.Write("Question id :");
                            test.Id = Guid.Parse(Console.ReadLine());

                            Console.Write("Question text :");
                            test.QuestionText = Console.ReadLine();

                            Console.Write("A variant :");
                            test.AVariant = Console.ReadLine();

                            Console.Write("B variant :");
                            test.BVariant = Console.ReadLine();

                            Console.Write("C variant :");
                            test.CVariant = Console.ReadLine();

                            Console.Write("Answer A/B/C :");
                            test.Answer = Console.ReadLine();

                            var result = testService.UpdateTest(test.Id);
                            if (result == true)
                            {
                                Console.WriteLine("Updated . . . ");
                            }
                            else
                            {
                                Console.WriteLine("Error . . . ");
                            }
                        }
                        else if (option == 9)
                        {
                            Console.Write("Enter id :");
                            var id = Guid.Parse(Console.ReadLine());
                            var test = testService.GetById(id);
                            Console.WriteLine($"id : {test.Id}");
                            Console.WriteLine($"Question text : {test.QuestionText}");
                            Console.WriteLine($"A variant : {test.AVariant}");
                            Console.WriteLine($"B variant : {test.BVariant}");
                            Console.WriteLine($"C variant : {test.CVariant}");
                            Console.WriteLine($"Answer : {test.Answer}");
                            Console.WriteLine();
                        }
                        else if (option == 10)
                        {
                            var tests = testService.GetAllTests();
                            foreach (var test in tests)
                            {
                                Console.WriteLine($"id : {test.Id}");
                                Console.WriteLine($"Question text : {test.QuestionText}");
                                Console.WriteLine($"A variant : {test.AVariant}");
                                Console.WriteLine($"B variant : {test.BVariant}");
                                Console.WriteLine($"C variant : {test.CVariant}");
                                Console.WriteLine($"Answer : {test.Answer}");
                                Console.WriteLine();
                            }
                        }
                        else if (option == 11)
                        {
                            Console.Write("Enter :");
                            var choice = int.Parse(Console.ReadLine());
                            var tests = testService.GetRandomTests(choice);

                            foreach (var test in tests)
                            {
                                Console.WriteLine($"id : {test.Id}");
                                Console.WriteLine($"Question text : {test.QuestionText}");
                                Console.WriteLine($"A variant : {test.AVariant}");
                                Console.WriteLine($"B variant : {test.BVariant}");
                                Console.WriteLine($"C variant : {test.CVariant}");
                                Console.WriteLine($"Answer : {test.Answer}");
                                Console.WriteLine();
                            }

                        }
                        Console.ReadKey();
                        Console.Clear();
                    }

                }
                else
                {
                    Console.WriteLine("  E R R O R ");
                }

            }
        }
        public static void StudentMenu()
        {
            ITestService studentServise = new TestService();
            while (true)
            {
                Console.Write("Enter Login : ");
                var login = Console.ReadLine();
                Console.Write("Enter Password : ");
                var password = Console.ReadLine();
                var cheek = studentServise.ChekLogin(login, password);
                if (cheek is true)
                {
                    while (true)
                    {
                        var testService = new TestService();
                        Console.WriteLine("1. Get All tests : ");
                        Console.WriteLine("2. Get Random tests : ");
                        Console.Write("Choose : ");
                        var option = int.Parse(Console.ReadLine());
                        if (option == 1)
                        {
                            var tests = testService.GetAllTests();
                            var count = 0;
                            foreach (var test in tests)
                            {
                                Console.WriteLine($"{test.QuestionText}");
                                Console.WriteLine($"A {test.AVariant}");
                                Console.WriteLine($"B {test.BVariant}");
                                Console.WriteLine($"C {test.CVariant}");
                                Console.Write("Enter Answer A/B/C : ");
                                var answer = Console.ReadLine();
                                if (answer == test.Answer)
                                {
                                    count++;
                                }

                            }
                            Console.WriteLine($"Correct Answer : {count}");
                        }
                        else if (option == 2)
                        {
                            Console.Write("Enter :");
                            var choice = int.Parse(Console.ReadLine());
                            var tests = testService.GetRandomTests(choice);
                            var count = 0;
                            foreach (var test in tests)
                            {

                                Console.WriteLine($"{test.QuestionText}");
                                Console.WriteLine($"A {test.AVariant}");
                                Console.WriteLine($"B {test.BVariant}");
                                Console.WriteLine($"C {test.CVariant}");
                                Console.Write("Enter Answer A/B/C : ");
                                var answer = Console.ReadLine();
                                if (answer == test.Answer)
                                {
                                    count++;
                                }
                            }
                            Console.WriteLine($"Correct Answer : {count}");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("error . . . ");
                }
            }
        }
    }
}
