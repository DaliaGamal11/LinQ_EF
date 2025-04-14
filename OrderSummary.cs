using System.Collections.Generic;
using System.Numerics;
//check 
namespace Q7
{
    class Order
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
    }

    class Customer
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public List<Order> Orders { get; set; }
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
                Orders = new List<Order>
                {
                   new Order { OrderId = 101, OrderDate = DateTime.Now.AddDays(-5), TotalAmount = 750 },
                   new Order { OrderId = 102, OrderDate = DateTime.Now.AddDays(-20), TotalAmount = 1200 }
                }
            },
              new Customer
              {
                CustomerId = 2,
                Name = "Ramy",
                Orders = new List<Order>
                {
                  new Order { OrderId = 103, OrderDate = DateTime.Now.AddDays(-40), TotalAmount = 900 }
                }
              },
              new Customer
              {
                CustomerId = 3,
                Name = "Samy",
                Orders = new List<Order>
                {
                  new Order { OrderId = 104, OrderDate = DateTime.Now.AddDays(-15), TotalAmount = 450 }
                }
              }
            };
            /*Retrieve:
            1.Customers who have placed at least 1 order in the last 30 days.
            2.Show Customer Name and a list of their recent orders(ID & TotalAmount).
            3.Sort customers by total order amount(highest to lowest).*/
            var result = customers.Where(Customer => Customer.Orders.Any(o => o.OrderDate >= DateTime.Now.AddDays(-30)))
                .Select(c => new
                {
                    c.Name,
                    Orders = c.Orders
                    .Where(o => o.OrderDate >= DateTime.Now.AddDays(-30))  
                    .OrderByDescending(o => o.TotalAmount)  
                    .ToList(),
                    TotalAmount = c.Orders
                    .Where(o => o.OrderDate >= DateTime.Now.AddDays(-30))  
                    .Sum(o => o.TotalAmount)  
                })
                .OrderByDescending(Customer => Customer.TotalAmount);

            foreach (var customer in result)
            {
                Console.WriteLine($"Customer: {customer.Name}");
                foreach (var order in customer.Orders)
                {
                    Console.WriteLine($"  Order ID: {order.OrderId}, Total Amount: {order.TotalAmount}");
                }
                Console.WriteLine($"Total Amount of Recent Orders: {customer.TotalAmount}\n");
            }
        }
    }
}
