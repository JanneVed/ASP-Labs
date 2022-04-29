using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab__2_Linq.Models
{
    public class Methods
    {
        public static void MainMenu()
        {
            using (Lab2_ASP_Course context = new Lab2_ASP_Course())
            {
                while (true)
                {
                    Console.Write("Welcome User!\n1. Get Data\n2. Update Data\nWhat do you want to do?: ");
                    int choice = Convert.ToInt32(Console.ReadLine());

                    if (choice == 1)
                    {
                        GetDataMenu(context);
                        break;
                    }
                    else if (choice == 2)
                    {
                        UpdateDataMenu(context);
                        break;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("A number between 1 and 2 must be entered!");
                    }
                }
            }
            
        }
        static void GetDataMenu(Lab2_ASP_Course context)
        {
            while (true)
            {
                Console.Write("What you want to see?\n" +
                    "1. Get all Teacher that educate in...\n" +
                    "2. Get all Students with their teachers\n" +
                    "3. Get all Students that are ongoing in...\n" +
                    ": ");
                int choice = Convert.ToInt32(Console.ReadLine());

                if (choice == 1)
                {
                    GetTeachersFromCourse(context);
                    break;
                }
                else if (choice == 2)
                {
                    GetStudentsWithTeachers(context);
                    break;
                }
                else if (choice == 3)
                {
                    GetStudentsWithCourse(context);
                    break;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("A number between 1 and 3 must be entered!");
                } 
            }
        }
        static void GetTeachersFromCourse(Lab2_ASP_Course context)
        {
            Console.Write("What is the Teacher educating in?: ");
            string course = Console.ReadLine();

            var teachers =
                from t in context.Teachers
                join c in context.Courses on t.TeacherId equals c.TeacherId
                where c.CourseName == course
                select t;

            if (teachers.Count() == 0)
                Console.WriteLine($"{teachers.Count()} results found!\n" +
                    "Result Reasons:\n" +
                    "Course might have been spelled incorrectly.\n" +
                    "No teachers might be assigned to this course yet.");

            foreach (var teacher in teachers)
            {
                Console.WriteLine($"Name: {teacher.FirstName} {teacher.Lastname}");
            }
        }
        static void GetStudentsWithTeachers(Lab2_ASP_Course context)
        {
            var studentTeachers =
                from sc in context.SchoolClasses
                join s in context.Students on sc.ClassId equals s.ClassId
                join ci in context.CourseInfos on sc.ClassId equals ci.ClassId
                join c in context.Courses on ci.CourseId equals c.CourseId
                join t in context.Teachers on c.TeacherId equals t.TeacherId
                where ci.ClassId == s.ClassId && ci.CourseId == c.CourseId && c.TeacherId == t.TeacherId
                orderby s.FirstName
                select new
                {
                    s,
                    c,
                    t
                };

            foreach (var studentTeacher in studentTeachers)
            {
                Console.WriteLine($"{studentTeacher.s.FirstName}\t{studentTeacher.s.LastName}\t" +
                $"{studentTeacher.t.FirstName}\t{studentTeacher.t.Lastname}\t" +
                $"{studentTeacher.c.CourseName}\n");
            }
        }
        static void GetStudentsWithCourse(Lab2_ASP_Course context)
        {
            Console.WriteLine("What Course do you want to look for");
            string course = Console.ReadLine();
            var studentWithCourse =
                from sc in context.SchoolClasses
                join s in context.Students on sc.ClassId equals s.ClassId
                join ci in context.CourseInfos on sc.ClassId equals ci.ClassId
                join c in context.Courses on ci.CourseId equals c.CourseId
                join t in context.Teachers on c.TeacherId equals t.TeacherId
                where ci.ClassId == s.ClassId && ci.CourseId == c.CourseId && c.TeacherId == t.TeacherId && c.CourseName == course
                orderby s.FirstName
                select new
                {
                    s,
                    t,
                };

            if (studentWithCourse.Count() == 0)
                Console.WriteLine($"{studentWithCourse.Count()} results found!\n" +
                    "Result Reasons:\n" +
                    "Course might have been spelled incorrectly.\n" +
                    "Course doesn't exist yet.");

            foreach (var student in studentWithCourse)
            {
                Console.WriteLine($"Student: {student.s.FirstName}\t{student.s.LastName}\tTeacher: {student.t.FirstName}\t{student.t.Lastname}");
            }
        }

        static void UpdateDataMenu(Lab2_ASP_Course context)
        {
            while (true)
            {
                Console.Write("What you want to edit?\n" +
                    "1. Update Courses\n" +
                    "2. Update Teachers Courses\n" +
                    ": ");
                int choice = Convert.ToInt32(Console.ReadLine());

                if (choice == 1)
                {
                    UpdateCourse(context);
                    break;
                }
                else if (choice == 2)
                {
                    UpdateCourseTeacher(context);
                    break;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("A number between 1 and 3 must be entered!");
                }
            }
            static void UpdateCourse(Lab2_ASP_Course context)
            {
                Console.Write("What Course would you like to change?: ");
                string courseName = Console.ReadLine();

                var selectedCourse =
                    from c in context.Courses
                    where c.CourseName == courseName
                    select c;

                Console.Write("What would you like to change it to?: ");
                string newCourse = Console.ReadLine();

                foreach (var course in selectedCourse)
                {
                    course.CourseName = newCourse;
                }
                context.SaveChanges();
            }
            static void UpdateCourseTeacher(Lab2_ASP_Course context)
            {
                var teachers =
                    from t in context.Teachers
                    select t;
                Console.WriteLine("Teachers: ");
                foreach (var teacher in teachers)
                {
                    Console.WriteLine($"{teacher.TeacherId}. {teacher.FirstName}");
                }
                Console.Write("Select Teacher: ");
                int choice = Convert.ToInt32(Console.ReadLine());

                var selectedCourse =
                    from t in context.Teachers
                    join c in context.Courses on t.TeacherId equals c.TeacherId
                    where c.TeacherId == choice
                    select c;

                Console.WriteLine("Select new Teacher: ");
                int newTeacherId = Convert.ToInt32(Console.ReadLine());

                foreach (var course in selectedCourse)
                {
                    course.TeacherId = newTeacherId;
                }
                context.SaveChanges();
            }
        }
        public static void PopulateTables(Lab2_ASP_Course context)
        {
            // Teachers

            //for (int i = 1; i <= 3; i++)
            //{
            //    var teacher = new Teacher()
            //    {
            //        FirstName = $"Teach{i}",
            //        Lastname = $"er{i}",
            //        Adress = $"Lärgatan {i}",
            //        WorkNumber = $"123456789{i}",
            //        Email = $"Teach.er{i}@theschoolname.com"
            //    };
            //    context.Add(teacher);
            //}
            //context.SaveChanges();

            // Classes

            //var aClass = new SchoolClass()
            //{
            //    ClassName = "1A"
            //};
            //context.Add(aClass);
            //var bClass = new SchoolClass()
            //{
            //    ClassName = "1B"
            //};
            //context.Add(bClass);
            //context.SaveChanges();

            // Students

            //int id = 1;
            //for (int i = 1; i <= 20; i++)
            //{
            //    if (i == 11)
            //        id = 2;

            //    var student = new Student()
            //    {
            //        FirstName = $"Stud{i}",
            //        LastName = $"ent{i}",
            //        Address = $"Studentgatan {i}",
            //        Email = $"Stud.ent{i}@stu.theschoolname.com",
            //        Number = $"123456789{i}",
            //        ClassId = id
            //    };
            //    context.Add(student);
            //}
            //context.SaveChanges();

            // Courses

            //var prog1 = new Course()
            //{
            //    CourseName = "Programming 1",
            //    Points = 20,
            //    TeacherId = 1
            //};
            //context.Add(prog1);
            //var prog2 = new Course()
            //{
            //    CourseName = "Programming 2",
            //    Points = 20,
            //    TeacherId = 1
            //};
            //context.Add(prog2);
            //var dbs1 = new Course()
            //{
            //    CourseName = "Database 1",
            //    Points = 20,
            //    TeacherId = 2
            //};
            //context.Add(dbs1);
            //var dbs2 = new Course()
            //{
            //    CourseName = "Database 2",
            //    Points = 20,
            //    TeacherId = 2
            //};
            //context.Add(dbs2);
            //var html = new Course()
            //{
            //    CourseName = "HTML",
            //    Points = 20,
            //    TeacherId = 3
            //};
            //context.Add(html);
            //var css = new Course()
            //{
            //    CourseName = "CSS",
            //    Points = 20,
            //    TeacherId = 3
            //};
            //context.Add(css);
            //var js = new Course()
            //{
            //    CourseName = "Javascript",
            //    Points = 40,
            //    TeacherId = 3
            //};
            //context.Add(js);
            //context.SaveChanges();

            // CourseInfo

            //var prog1 = new CourseInfo()
            //{
            //    StartDate = new DateTime(2023, 1, 9),
            //    EndDate = new DateTime(2023, 2, 5),
            //    CourseId = 1,
            //    ClassId = 1
            //};
            //context.Add(prog1);

            //var prog2 = new CourseInfo()
            //{
            //    StartDate = new DateTime(2023, 2, 6),
            //    EndDate = new DateTime(2023, 3, 5),
            //    CourseId = 2,
            //    ClassId = 1
            //};
            //context.Add(prog2);

            //var dbs1 = new CourseInfo()
            //{
            //    StartDate = new DateTime(2023, 6, 9),
            //    EndDate = new DateTime(2023, 4, 2),
            //    CourseId = 3,
            //    ClassId = 1
            //};
            //context.Add(dbs1);

            //var dbs2 = new CourseInfo()
            //{
            //    StartDate = new DateTime(2023, 4, 3),
            //    EndDate = new DateTime(2023, 4, 30),
            //    CourseId = 4,
            //    ClassId = 1
            //};
            //context.Add(dbs2);

            //var html = new CourseInfo()
            //{
            //    StartDate = new DateTime(2023, 1, 9),
            //    EndDate = new DateTime(2023, 2, 5),
            //    CourseId = 5,
            //    ClassId = 2
            //};
            //context.Add(html);

            //var css = new CourseInfo()
            //{
            //    StartDate = new DateTime(2023, 2, 6),
            //    EndDate = new DateTime(2023, 3, 5),
            //    CourseId = 6,
            //    ClassId = 2
            //};
            //context.Add(css);

            //var js = new CourseInfo()
            //{
            //    StartDate = new DateTime(2023, 3, 6),
            //    EndDate = new DateTime(2023, 4, 30),
            //    CourseId = 7,
            //    ClassId = 2
            //};
            //context.Add(js);

            //context.SaveChanges();
        }
    }
}
