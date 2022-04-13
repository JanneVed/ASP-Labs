using Lab_1_Entity_Framework.Models;
using System;
using System.Linq;

namespace Lab_1_Entity_Framework
{
    class Program
    {
        static void Main(string[] args)
        {
            //PopulateTables()
            MainMenu();
        }

        static void MainMenu()
        {
            using DbConection context = new DbConection();
            {
                while (true)
                {
                    Console.Write("Main Menu\n\nWelcome User!\nWho is using the program?\n\n" +
                        "1. Admin\n2. Employee\n\n0. Quit\n\n" +
                        "Enter a number between 0-2 and hit enter: ");

                    int role = Convert.ToInt32(Console.ReadLine());
                    if (role == 0)
                    {
                        break;
                    }
                    else if (role == 1)
                    {
                        while (true)
                        {
                            Console.Clear();
                            Console.Write("Welcome Admin!\nWhat do you want to do?\n\n" +
                                "1. Register Employee\n2. Check Employees leave histories\n3. Check if Employee has a request for a leave\n\n0. Return to main menu\n\n" +
                                "Enter a number between 0-3 and hit enter: ");

                            int choice = Convert.ToInt32(Console.ReadLine());

                            if (choice == 0)
                            {
                                Console.Clear();
                                break;
                            }
                            else if (choice == 1)
                            {
                                Console.Clear();
                                RegisterEmployee(context);
                            }
                            else if (choice == 2)
                            {
                                Console.Clear();
                                CheckLeaveHistories(context);
                            }
                            else if (choice == 3)
                            {
                                Console.Clear();
                                CheckLeaveRequests(context);
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("You can only choose number between 1-3!\n");
                            }
                        }
                    }
                    else if (role == 2)
                    {
                        while (true)
                        {
                            Console.Clear();
                            Console.Write("Welcome Employee!\nWhat do you want to do?\n\n" +
                                "1. Request a leave\n\n0. Return to main menu\n\n" +
                                "Enter a number between 0-1 and hit enter: ");

                            int choice = Convert.ToInt32(Console.ReadLine());

                            if (choice == 1)
                            {
                                Console.Clear();
                                RequestForLeave(context);
                            }
                            else if (choice == 0)
                            {
                                Console.Clear();
                                break;
                            }
                        }
                    }
                }
            }
        }

        // Admin function
        static void RegisterEmployee(DbConection context)
        {
            Console.WriteLine("Registering Employee\n\nField with * is required\n\nType Cancel to retrun to previouse step");
            Console.Write("*First Name: ");
            string firstName = Console.ReadLine();
            if (firstName.ToLower() == "cancel")
            {
                Console.Clear();
                return;
            };
            Console.Write("*Last Name: ");
            string lastName = Console.ReadLine();
            if (lastName.ToLower() == "cancel")
            {
                Console.Clear();
                return;
            };
            Console.Write("*Adress: ");
            string address = Console.ReadLine();
            if (address.ToLower() == "cancel")
            {
                Console.Clear();
                return;
            };
            Console.Write("*E-mail: ");
            string eMail = Console.ReadLine();
            if (eMail.ToLower() == "cancel")
            {
                Console.Clear();
                return;
            };
            Console.Write("Work Number: ");
            string workNumber = Console.ReadLine();
            if (workNumber.ToLower() == "cancel")
            {
                Console.Clear();
                return;
            };

            Employee employee = new Employee()
            {
                FirstName = firstName,
                LastName = lastName,
                Address = address,
                Email = eMail,
                WorkNumber = workNumber
            };

            context.Add(employee);
            context.SaveChanges();

            Console.Clear();
            Console.WriteLine("Employee added!\n\n");
        }

        // Admin function
        static void CheckLeaveHistories(DbConection context)
        {
            Console.Write("Check Employees leave histories\n\nWhich employee would you like to check?\nFirst name: ");
            string firstName = Console.ReadLine();
            Console.Write("Last name: ");
            string lastName = Console.ReadLine();

            var person = 
                from e in context.Employees
                where e.FirstName == firstName && e.LastName == lastName
                select e;

            int currentEmployeeId = 0;
            foreach (var Employee in person)
            {
                currentEmployeeId = Employee.EmployeeId;
            }

            var leave = 
                from l in context.Leaves
                where l.EmployeeId == currentEmployeeId
                select l;

            foreach (var item in leave)
            {
                Console.WriteLine($"Name: {firstName} {lastName}\nRegistered leave: {item.DateOfRegister}\nType of Leave: {item.TypeOfLeave}");
            }
            Console.ReadKey();
        }

        // Admin function
        static void CheckLeaveRequests(DbConection context)
        {
            while (true)
            {
                Console.Write("Check if Employee has a request for a leave\n\nWhat month do you want to check for requests?(Month in number)\n\n" +
                    "Enter 0 to return to Main menu: ");
                int month = Convert.ToInt32(Console.ReadLine());

                if (month == 0)
                {
                    break;
                }
                var requests =
                    from d in context.Leaves
                    join p in context.Employees on d.EmployeeId equals p.EmployeeId
                    where d.DateOfRegister.Month == month && d.EmployeeId == p.EmployeeId
                    select new
                    {
                        p.FirstName,
                        p.LastName,
                        d.EndDate,
                        d.StartDate,
                        d.DateOfRegister
                    };

                foreach (var request in requests)
                {
                    if (request.EndDate == null)
                    {
                        Console.WriteLine($"\nEmployee: {request.FirstName} {request.LastName}" +
                            $"\nTotal Days Requested: [No end date provided]\n" +
                            $"\nDate of Request submited: {request.DateOfRegister}");
                    }
                    else if (request.EndDate.HasValue)
                    {
                        Console.WriteLine($"\nEmployee: {request.FirstName} {request.LastName}" +
                            $"\nTotal Days Requested: {(request.EndDate.Value - request.StartDate).Days}" +
                            $"\nDate of Request submited: {request.DateOfRegister}");
                    }
                }
                Console.ReadKey();
            }
        }

        // Employee function
        static void RequestForLeave(DbConection context)
        {
            Console.WriteLine("Request a leave\n\nWhat type of leave are you requesting?");
            string[] choices = new string[] { "Care Of Child", "Parental leave", "Vacation", "Sickness", "Compensatory Time Off" };
            for (int type = 0; type < choices.Length; type++)
            {
                Console.WriteLine($"\n{type+1}. {choices[type]}");
            }
            Console.Write("\n\nEnter the number of your choice and hit enter: ");
            int choice = Convert.ToInt32(Console.ReadLine());
            choice--;

            string leaveType = choices[choice];

            if (choice == 0 || choice == 3)
            {
                Console.Write("Enter a Start Date(YYYY-MM-DD format): ");
                DateTime startDate = Convert.ToDateTime(Console.ReadLine());
                Console.Write("Enter your employee ID: ");
                int employeeId = Convert.ToInt32(Console.ReadLine());

                Leave leave = new Leave()
                {
                    TypeOfLeave = leaveType,
                    StartDate = startDate,
                    EmployeeId = employeeId,
                    DateOfRegister = DateTime.Now
                };

                context.Add(leave);
                context.SaveChanges();
            }
            else if (choice != 0 || choice != 3)
            {
                Console.Write("Enter a Start Date(YYYY-MM-DD format): ");
                DateTime startDate = Convert.ToDateTime(Console.ReadLine());
                Console.Write("Enter a End Date(YYYY-MM-DD format): ");
                DateTime.TryParse(Console.ReadLine(), out DateTime validDate);
                DateTime endDate = validDate;
                Console.Write("Enter your employee ID: ");
                int employeeId = Convert.ToInt32(Console.ReadLine());

                Leave leave = new Leave()
                {
                    TypeOfLeave = leaveType,
                    StartDate = startDate,
                    EndDate = endDate,
                    EmployeeId = employeeId,
                    DateOfRegister = DateTime.Now
                };

                context.Add(leave);
                context.SaveChanges();
                Console.Clear();
                Console.Write("Request has been submited!\n\n");
            }
            else
            {
                Console.WriteLine("You must enter a number bewteen given options!");
            }
        }

        static void PopulateTables(DbConection context)
        {
            // Added 10 employees
            for (int i = 0; i < 10; i++)
            {
                Employee employee = new Employee()
                {
                    FirstName = $"John {i}",
                    LastName = $"Doe {i}",
                    Address = $"LivingStreet {i}",
                    Email = $"John.Doe{i}@YouGotMail.com",
                    WorkNumber = $"123456789{i}"
                };

                context.Add(employee);
            };

            context.SaveChanges();
        }
    }
}
