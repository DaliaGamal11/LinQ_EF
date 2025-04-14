namespace Q6
{
    class Product
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
    }



    internal class Program
    {
        static void Main(string[] args)
        {
            List<Product> products = new List<Product>
            {
                new Product { Name = "Laptop", Category = "Electronics", Price = 1200 },
                new Product { Name = "Smartphone", Category = "Electronics", Price = 800 },
                new Product { Name = "Tablet", Category = "Electronics", Price = 600 },
                new Product { Name = "Smartwatch", Category = "Electronics", Price = 300 },
                new Product { Name = "TV", Category = "Electronics", Price = 1500 },
                new Product { Name = "Chair", Category = "Furniture", Price = 200 },
                new Product { Name = "Table", Category = "Furniture", Price = 500 }
            };
            /*Retrieve:
             1.The 5 most expensive products.
             2.Only from the Electronics category.
             3.Show Product Name, Category, and Price sorted from highest to lowest price.*/
            var result = products.Where(Product => Product.Category.Contains("Electronics"))
               .OrderByDescending(Product => Product.Price)
               .Take(5)
               .Select(Product => new { Product.Name, Product.Category ,Product.Price});

            foreach (var product in result)
            {
                Console.WriteLine(product);

            }


        }
    }
}
