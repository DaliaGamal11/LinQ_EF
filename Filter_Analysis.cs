using System.Globalization;

namespace lab1
{
    class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Salary { get; set; }
    }
    class Department
    {
        public string Name { get; set; }
        public List<Employee> Employees { get; set; }
    }


    internal class Program
    {
        
        static void Main(string[] args)
        {
            List<Employee> employees = new List<Employee>
            {
             new Employee { Id = 1, Name = "Ali", Salary = 60000 },
             new Employee { Id = 2, Name = "Ramy", Salary = 45000 },
             new Employee { Id = 3, Name = "Samy", Salary = 75000 },
             new Employee { Id = 4, Name = "Hassan", Salary = 55000 },
             new Employee { Id = 5, Name = "Mariam", Salary = 52000 }
            };

            //Retrieve only the employees whose salary is greater than 50,000, and return their names and salaries.

            var Result1 =employees
                .Where(Employee => Employee.Salary>50000)
                .Select(Employee => new { Employee.Name, Employee.Salary })
                .ToList();
            Console.WriteLine("Employees with Salary > 50,000:");
            foreach (var emp in Result1)
            {
                Console.WriteLine($"{emp.Name} - {emp.Salary:c}");
            }

            Console.WriteLine("------------------------------------");
            List<Department> departments = new List<Department>
            {
              new Department
              {
                 Name = "IT Development",
                 Employees = new List<Employee>
                 {
                   new Employee { Id = 1, Name = "Ali", Salary = 65000 },
                   new Employee { Id = 2, Name = "Ramy", Salary = 72000 }
                 }
              },
              new Department
              {
                 Name = "HR",
                 Employees = new List<Employee>
                 {
                  new Employee { Id = 3, Name = "Samy", Salary = 50000 },
                  new Employee { Id = 4, Name = "Hassan", Salary = 48000 }
                 }
              },
              new Department
              {
                 Name = "IT Security",
                 Employees = new List<Employee>
                 {
                  new Employee { Id = 5, Name = "Mariam", Salary = 90000 }
                 }
              }
            };
            //Find all employees who:
            //1.Work in a department starting with "IT".
            //2.Have a salary greater than 60,000.
            //3.Return Employee Name, Department Name, and Salary sorted from highest to lowest salary.
            var Result2 = departments
               .Where(Department => Department.Name.StartsWith("IT"))
               .SelectMany(department => department.Employees)//,(department, employee) => new { department.Name, employee.Name, employee.Salary }
               .Where(employee => employee.Salary > 60000)
               .OrderByDescending(employee => employee.Salary)
               .Select(employee => new { employee.Name, employee.Salary });
               
            foreach (var dep in Result2)
            {
                Console.WriteLine(dep);
            }





        }


    }

    

}
