namespace Q3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> electronicsProducts = new List<string> { "Laptop", "Smartphone", "Tablet", "Smartwatch" };
            List<string> furnitureProducts = new List<string> { "Table", "Chair", "Smartwatch", "Laptop", "Sofa" };
            //Retrieve all distinct products from both lists and sort them alphabetically.
            var result = electronicsProducts
                .Concat(furnitureProducts)
                .Distinct()
                .OrderBy(Product=>Product);
            foreach (var Product in result)
                Console.WriteLine(Product);
        }
    }
}
