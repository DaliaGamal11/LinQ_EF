using System.Runtime.ConstrainedExecution;

namespace Q5
{
    class Purchase
    {
        public int PurchaseId { get; set; }
        public DateTime PurchaseDate { get; set; }
        public decimal Amount { get; set; }
    }

    class Customer
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public List<Purchase> Purchases { get; set; }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            List<Customer> customers = new List<Customer>
            {
                new Customer
                {
                    CustomerId = 1,
                    Name = "Ali",
                    Purchases = new List<Purchase>
                    {
                        new Purchase { PurchaseId = 301, PurchaseDate = DateTime.Now.AddDays(-5), Amount = 1200 },
                        new Purchase { PurchaseId = 302, PurchaseDate = DateTime.Now.AddDays(-20), Amount = 500 }
                    }
                },
                new Customer
                {
                    CustomerId = 2,
                    Name = "Ramy",
                    Purchases = new List<Purchase>
                    {
                        new Purchase { PurchaseId = 303, PurchaseDate = DateTime.Now.AddDays(-40), Amount = 750 }
                    }
                },
                new Customer
                {
                    CustomerId = 3,
                    Name = "Samy",
                    Purchases = new List<Purchase>
                    {
                        new Purchase { PurchaseId = 304, PurchaseDate = DateTime.Now.AddDays(-15), Amount = 300 }
                    }
                }
            };
            // 1. Group customers by the number of purchases
            var groupedByPurchases = customers
                .GroupBy(c => c.Purchases.Count)
                .Select(group => new
                {
                    PurchaseCount = group.Key,
                    Customers = group.ToList()
                });

            Console.WriteLine("Customers grouped by the number of purchases:");
            foreach (var group in groupedByPurchases)
            {
                Console.WriteLine($"\nCustomers with {group.PurchaseCount} purchase(s):");
                foreach (var customer in group.Customers)
                {
                    Console.WriteLine($"- {customer.Name} (CustomerId: {customer.CustomerId})");
                }
            }

            // 2. Find the total amount spent per customer
            var totalAmountSpent = customers
                .Select(c => new
                {
                    c.Name,
                    TotalAmount = c.Purchases.Sum(p => p.Amount)
                });

            Console.WriteLine("\nTotal amount spent per customer:");
            foreach (var customer in totalAmountSpent)
            {
                Console.WriteLine($"{customer.Name}: ${customer.TotalAmount}");
            }

            // 3. Retrieve customers who made more than one purchase in the last 30 days
            var recentCustomers = customers
                .Where(c => c.Purchases.Count(p => p.PurchaseDate >= DateTime.Now.AddDays(-30)) > 1)
                .Select(c => new { c.Name, c.CustomerId });

            Console.WriteLine("\nCustomers who made more than one purchase in the last 30 days:");
            foreach (var customer in recentCustomers)
            {
                Console.WriteLine($"- {customer.Name} (CustomerId: {customer.CustomerId})");
            }

        }
    }
}
