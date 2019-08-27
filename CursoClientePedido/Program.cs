using System;
using CursoClientePedido.Entities;
using CursoClientePedido.Entities.Enums;
using System.Globalization;

namespace CursoClientePedido
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Entter Client Data:");
            Console.Write("Name:");
            string nameCli = Console.ReadLine();
            Console.Write("Email:");
            string emailCli = Console.ReadLine();
            Console.Write("Birth Date (DD/MM/YYYY):");
            DateTime bdate = DateTime.Parse(Console.ReadLine());

            Client cli = new Client(nameCli, emailCli, bdate);

            Console.WriteLine("Entter Order Data:");
            Console.Write("Status:");
            OrderStatus st = Enum.Parse<OrderStatus>(Console.ReadLine());

            Order Ord = new Order(DateTime.Now, st, cli);

            Console.Write("How Many Itens To This Order?:");
            int numItens = int.Parse(Console.ReadLine());

            for (int i=1; i<=numItens; i++)
            {
                Console.WriteLine($"Enter #{i} item data:");
                Console.Write("Product Name:");
                string nameprod = Console.ReadLine();
                Console.Write("Product Price:");
                double price = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.Write("Quantity:");
                int quant = int.Parse(Console.ReadLine());

                Product Prod = new Product(nameprod, price);
                OrderItem item = new OrderItem(quant, price, Prod);

                Ord.AddItem(item);
            }

            Console.WriteLine("ORDER SUMARY:");
            Console.WriteLine(Ord.ToString());
        }
    }
}
