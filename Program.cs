namespace Q2
{
    class Order
    {
        public int OrderId { get; set; }
        public string CustomerName { get; set; }
        public DateTime OrderDate { get; set; }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            List<Order> orders = new List<Order>
            {
                   new Order { OrderId = 101, CustomerName = "Ali", OrderDate = DateTime.Now.AddDays(-5) },
                   new Order { OrderId = 102, CustomerName = "Ramy", OrderDate = DateTime.Now.AddDays(-20) },
                   new Order { OrderId = 103, CustomerName = "Samy", OrderDate = DateTime.Now.AddDays(-40) },
                   new Order { OrderId = 104, CustomerName = "Hassan", OrderDate = DateTime.Now.AddDays(-15) }
            };
           //Retrieve only the orders that were placed in the last 30 days and return Order ID, Customer Name, and Order Date.
            var result= orders
                .Where(order=>order.OrderDate>= DateTime.Now.AddDays(-30))
                .Select(order =>new { order.OrderId, order.CustomerName, order.OrderDate })
                .ToList();
            Console.WriteLine("\nOrders placed in the last 30 days:");
            foreach (var order in result)
            {
                Console.WriteLine($"Order ID: {order.OrderId}, Customer: {order.CustomerName}, Date: {order.OrderDate.ToShortDateString()}");
            }
        }
    }
}
