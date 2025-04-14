using System;
using System.Collections.Generic;

namespace Q4
{
    class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Salary { get; set; }
    }

    class Project
    {
        public string Name { get; set; }
        public List<Employee> TeamMembers { get; set; }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            List<Project> projects = new List<Project>
            {
                new Project
                {
                    Name = "AI Development",
                    TeamMembers = new List<Employee>
                    {
                        new Employee { Id = 1, Name = "Ali", Salary = 85000 },
                        new Employee { Id = 2, Name = "Ramy", Salary = 78000 }
                    }
                },
                new Project
                {
                    Name = "HR Automation",
                    TeamMembers = new List<Employee>
                    {
                        new Employee { Id = 3, Name = "Samy", Salary = 60000 },
                        new Employee { Id = 4, Name = "Hassan", Salary = 55000 }
                    }
                },
                new Project
                {
                    Name = "Cybersecurity",
                    TeamMembers = new List<Employee>
                    {
                        new Employee { Id = 5, Name = "Mariam", Salary = 98000 }
                    }
                }
            };
            // 1. Group team members by project
            var groupedByProject = projects
                .Select(project => new
                {
                    ProjectName = project.Name,
                    TeamMembers = project.TeamMembers
                });

            Console.WriteLine("Team members grouped by project:");
            foreach (var projectGroup in groupedByProject)
            {
                Console.WriteLine($"\nProject: {projectGroup.ProjectName}");
                foreach (var member in projectGroup.TeamMembers)
                {
                    Console.WriteLine($"  - {member.Name} (Salary: {member.Salary})");
                }
            }

            // 2. Find the top 2 highest-paid employees per project
            var topPaidEmployees = projects
                .Select(project => new
                {
                    ProjectName = project.Name,
                    TopEmployees = project.TeamMembers
                        .OrderByDescending(employee => employee.Salary)
                        .Take(2)
                        .ToList()
                });

            Console.WriteLine("\nTop 2 highest-paid employees per project:");
            foreach (var project in topPaidEmployees)
            {
                Console.WriteLine($"\nProject: {project.ProjectName}");
                foreach (var employee in project.TopEmployees)
                {
                    Console.WriteLine($"  - {employee.Name} (Salary: {employee.Salary})");
                }
            }

            // 3. Get the total salary per project
            var totalSalaryPerProject = projects
                .Select(project => new
                {
                    ProjectName = project.Name,
                    TotalSalary = project.TeamMembers.Sum(employee => employee.Salary)
                });

            Console.WriteLine("\nTotal salary per project:");
            foreach (var project in totalSalaryPerProject)
            {
                Console.WriteLine($"Project: {project.ProjectName} - Total Salary: {project.TotalSalary}");
            }



        }
    }
}
