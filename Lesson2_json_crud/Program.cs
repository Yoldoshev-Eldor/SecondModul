using Lesson2_json_crud.Models;
using Lesson2_json_crud.Services;
using System;
using System.Dynamic;

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
            var directorService = new TeacherService();
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
            var teacherService = new StudentService();
            while (true)
            {
                Console.Write("Enter Login : ");
                var login = Console.ReadLine();
                Console.Write("Enter Password : ");
                var password = Console.ReadLine();
                var cheek = teacherService.CheekLogin(login, password);
                if (cheek is true)
                {
                    Console.WriteLine("1. Add Student : ");
                    Console.WriteLine("2. Delete Student : ");
                    Console.WriteLine("3. Update Student : ");
                    Console.WriteLine("4. Get By Id : ");
                    Console.WriteLine("5. Get All Student : ");
                    Console.Write("ch o o s e ==> : ");
                    var option = int.Parse(Console.ReadLine());
                    if (option == 1)
                    {

                    }
                    else if (option == 2)
                    {

                    }
                    else if (option == 3)
                    {

                    }
                    else if (option == 4)
                    {

                    }
                    else if (option == 5)
                    {

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

        }
    }
}
