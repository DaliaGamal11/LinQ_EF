namespace Q2
{
    class Transaction
    {
        public int TransactionId { get; set; }
        public string CustomerName { get; set; }
        public DateTime TransactionDate { get; set; }
        public decimal Amount { get; set; }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            List<Transaction> transactions = new List<Transaction>
            {
                new Transaction { TransactionId = 201, CustomerName = "Ali", TransactionDate = DateTime.Now.AddDays(-5), Amount = 700 },
                new Transaction { TransactionId = 202, CustomerName = "Ramy", TransactionDate = DateTime.Now.AddDays(-20), Amount = 450 },
                new Transaction { TransactionId = 203, CustomerName = "Samy", TransactionDate = DateTime.Now.AddDays(-40), Amount = 900 },
                new Transaction { TransactionId = 204, CustomerName = "Hassan", TransactionDate = DateTime.Now.AddDays(-15), Amount = 300 }

            };
            //1.	The most recent 3 transactions.
            var recent = transactions.OrderBy(x => x.TransactionDate).Take(3)
                .Select(Transaction => new { Transaction.CustomerName, Transaction.TransactionDate });
            foreach (var transaction1 in recent)
                Console.WriteLine(transaction1);
            Console.WriteLine("---------------------");
            //2.The first transaction above $500.
            var above = transactions.Where(Transaction => Transaction.Amount > 500)
                .Take(1)
                .Select(transaction => new { transaction.TransactionId, transaction.CustomerName, transaction.Amount }); ;
            foreach (var transaction2 in above)
                Console.WriteLine(transaction2);
                Console.WriteLine("-------------------");
            //3.Skip the first 2 transactions and return the remaining.Dataset:
            var remaing = transactions.Skip(2).Select(Transaction => new { Transaction.CustomerName,Transaction.TransactionId, Transaction.TransactionDate });
            foreach (var transaction3 in remaing)
                Console.WriteLine(transaction3);
        }
    }
}
