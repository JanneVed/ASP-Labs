using Lab__2_Linq.Models;
using System;

namespace Lab__2_Linq
{
    class Program
    {
        static void Main(string[] args)
        {
            using (Lab2_ASP_Course context = new Lab2_ASP_Course())
            {
                PopulateTables(context);
                //Menus(context);
            }
        }
        static void PopulateTables(Lab2_ASP_Course context)
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
            //    ClassName = "A1"
            //};
            //context.Add(aClass);
            //var bClass = new SchoolClass()
            //{
            //    ClassName = "B1"
            //};
            //context.Add(bClass);
            //var cClass = new SchoolClass()
            //{
            //    ClassName = "C1"
            //};
            //context.Add(cClass);
            //var dClass = new SchoolClass()
            //{
            //    ClassName = "D1"
            //};
            //context.Add(dClass);
            //context.SaveChanges();

            // Students

            //int id = 1;
            //for (int i = 1; i <= 20; i++)
            //{
            //    if (i == 6)
            //        id++;
            //    if (i == 11)
            //        id++;
            //    if (i == 16)
            //        id++;

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
            //    Points = 10,
            //    TeacherId = 3
            //};
            //context.Add(html);
            //var css = new Course()
            //{
            //    CourseName = "CSS",
            //    Points = 10,
            //    TeacherId = 3
            //};
            //context.Add(css);
            //var js = new Course()
            //{
            //    CourseName = "Javascript",
            //    Points = 20,
            //    TeacherId = 3
            //};
            //context.Add(js);
            //context.SaveChanges();

            // ClassCourse

            var classCourse = new ClassCourse()
            {
                StartDate = new DateTime(2022, 5, 10)
            };
        }
    }
}
