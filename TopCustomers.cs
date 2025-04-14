namespace Q4
{
    class Customer
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public decimal TotalSpending { get; set; }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            List<Customer> customers = new List<Customer>
            {
               new Customer { CustomerId = 1, Name = "Ali", TotalSpending = 2500 },
               new Customer { CustomerId = 2, Name = "Ramy", TotalSpending = 800 },
               new Customer { CustomerId = 3, Name = "Samy", TotalSpending = 1800 },
               new Customer { CustomerId = 4, Name = "Hassan", TotalSpending = 1200 },
               new Customer { CustomerId = 5, Name = "Mariam", TotalSpending = 3000 }
              };
            //Find customers who have spent more than 1000 and return their name and spending sorted from highest to lowest.
            //Return only the top 3 customers.
            var result = customers
                .Where(Customer => Customer.TotalSpending > 1000)
                .Select(Customer => new { Customer.Name, Customer.TotalSpending })
                .OrderByDescending(customer => customer.TotalSpending)
                .Take(3);
            foreach (var c in result)
            {
                Console.WriteLine(c);
            }


        }
    }
}
