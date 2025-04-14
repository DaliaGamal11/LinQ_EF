using System.Collections.Generic;

namespace Lab2
{
    class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Score { get; set; }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>
            {
              new Student { Id = 1, Name = "Ali", Score = 90 },
              new Student { Id = 2, Name = "Ramy", Score = 75 },
              new Student { Id = 3, Name = "Samy", Score = 88 },
              new Student { Id = 4, Name = "Hassan", Score = 95 },
              new Student { Id = 5, Name = "Mariam", Score = 80 }
            };
            //1.The highest score.  
              var highest = students.Max(student => student.Score);
            //2.The lowest score.
              var lowest = students.Min(Student => Student.Score);
            //3.The average score.
            var avg = students.Average(student => student.Score);
            //4.The first student scoring above 85.
            var result = students.Where(student => student.Score > 85)
                .Select(student =>new { student.Name ,student.Score})
                .Take(1);
            Console.WriteLine($"Highest score: {highest}");
            Console.WriteLine($"Lowest score: {lowest}");
            Console.WriteLine($"Average score: {avg}");
            foreach (var s in result)
            {
                Console.WriteLine(s.Name);
            }
           
        }
    }
}
