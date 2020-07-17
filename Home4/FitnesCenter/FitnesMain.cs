using System;
using System.Collections.Generic;
using System.Linq;

namespace Home4.FitnesCenter
{
    public class FitnesMain
    {
        public static void Main(string[] args)
        {
            List<Customer> customers = new List<Customer>();
            Customer customer1 = new Customer(1, 1980, 12, 40);
            Customer customer2 = new Customer(2, 1987, 7, 42);
            Customer customer3 = new Customer(3, 1990, 4, 37);
            Customer customer4 = new Customer(4, 1988, 5, 38);
            Customer customer5 = new Customer(5, 1995, 1, 50);
            customers.Add(customer1);
            customers.Add(customer2);
            customers.Add(customer3);
            customers.Add(customer4);
            customers.Add(customer5);

            int minSession = customers.Min(customer => customer.Session);
            var res = from customer in customers
                      where customer.Session == minSession
                      select customer;

            Customer target = res.ToList()[res.ToList().Count - 1];        
            Console.WriteLine(target);
            Console.ReadKey();
        }
    }
}
