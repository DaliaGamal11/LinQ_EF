using System.Runtime.ConstrainedExecution;

namespace Q3
{
    class Book
    {
        public string Title { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            List<Book> books = new List<Book>
            {
                new Book { Title = "C# Basics", Category = "Programming", Price = 50 },
                new Book { Title = "Advanced C#", Category = "Programming", Price = 80 },
                new Book { Title = "Data Structures", Category = "Computer Science", Price = 60 },
                new Book { Title = "Operating Systems", Category = "Computer Science", Price = 90 },
                new Book { Title = "Business Strategies", Category = "Business", Price = 40 }
            };
            // 1. The total number of books in each category
            var totalBooks = books
                .GroupBy(book => book.Category)
                .Select(group => new
                {
                    Category = group.Key,
                    TotalBooks = group.Count()
                });

            // 2. The most expensive book in each category
            var mostExpensiveBooks = books
                .GroupBy(book => book.Category)
                .Select(group => new
                {
                    Category = group.Key,
                    MostExpensiveBook = group.OrderByDescending(book => book.Price).FirstOrDefault()
                });

            // 3. The average price of books per category
            var averagePrice = books
                .GroupBy(book => book.Category)
                .Select(group => new
                {
                    Category = group.Key,
                    AveragePrice = group.Average(book => book.Price)
                });

            
            Console.WriteLine("Total books per category:");
            foreach (var item in totalBooks)
            {
                Console.WriteLine($"{item.Category}: {item.TotalBooks} books");
            }

            Console.WriteLine("\nMost expensive book in each category:");
            foreach (var item in mostExpensiveBooks)
            {
                Console.WriteLine($"{item.Category}: {item.MostExpensiveBook?.Title} - ${item.MostExpensiveBook?.Price}");
            }

            Console.WriteLine("\nAverage price per category:");
            foreach (var item in averagePrice)
            {
                Console.WriteLine($"{item.Category}: ${item.AveragePrice:F2}");
            }



        }
    }
}
