using System;
using System.Collections.Generic;
using System.Linq;

namespace SydneyCoffee
{
    class Program
    {
        // Customer class to store customer data
        class Customer
        {
            public string Name { get; set; }
            public int Quantity { get; set; }
            public bool IsReseller { get; set; }
            public double Charge { get; set; }
        }

        static void Main(string[] args)
        {
            List<Customer> customers = new List<Customer>();
            int n = 2; // Number of customers

            Console.WriteLine("\t\t\t\tWelcome to use Sydney Coffee Program\n");

            // Loop to collect data for each customer
            for (int i = 0; i < n; i++)
            {
                Customer customer = new Customer();

                Console.Write("Enter customer name: ");
                customer.Name = Console.ReadLine();

                customer.Quantity = GetValidQuantity();

                Console.Write("Enter yes/no to indicate whether you are a reseller: ");
                customer.IsReseller = Console.ReadLine().ToLower() == "yes";

                // Calculate charge
                customer.Charge = CalculateCharge(customer.Quantity, customer.IsReseller);

                Console.WriteLine($"The total sales value from {customer.Name} is ${customer.Charge:F2}");
                Console.WriteLine("-----------------------------------------------------------------------------");

                customers.Add(customer);
            }

            // Summary
            Console.WriteLine("\t\t\t\t\tSummary of sales\n");
            Console.WriteLine("-----------------------------------------------------------------------------");
            Console.WriteLine("-----------------------------------------------------------------------------");

            Console.WriteLine(String.Format("{0,15}{1,10}{2,10}{3,10}",
                        "Name", "Quantity", "Reseller", "Charge"));

            foreach (var customer in customers)
            {
                Console.WriteLine(String.Format("{0,15}{1,10}{2,10}{3,10:F2}",
                       customer.Name, customer.Quantity, customer.IsReseller ? "Yes" : "No", customer.Charge));
            }

            Console.WriteLine("-----------------------------------------------------------------------------");
            Console.WriteLine("-----------------------------------------------------------------------------");

            // Find highest and lowest spender
            var highestSpender = customers.OrderByDescending(c => c.Charge).First();
            var lowestSpender = customers.OrderBy(c => c.Charge).First();

            Console.WriteLine($"The customer spending most is {highestSpender.Name} ${highestSpender.Charge:F2}");
            Console.WriteLine($"The customer spending least is {lowestSpender.Name} ${lowestSpender.Charge:F2}");
        }

        // Method to validate quantity input
        static int GetValidQuantity()
        {
            int quantity;
            do
            {
                Console.Write("Enter the number of coffee beans bags (bag/1kg): ");
                quantity = Convert.ToInt32(Console.ReadLine());

                if (quantity < 1 || quantity > 200)
                {
                    Console.WriteLine("Invalid Input!\nCoffee bags between 1 and 200 can be ordered.");
                }
            } while (quantity < 1 || quantity > 200);

            return quantity;
        }

        // Method to calculate charge
        static double CalculateCharge(int quantity, bool isReseller)
        {
            double pricePerBag = quantity <= 5 ? 36 : quantity <= 15 ? 34.5 : 32.7;
            double total = pricePerBag * quantity;
            return isReseller ? total * 0.8 : total;
        }
    }
}
