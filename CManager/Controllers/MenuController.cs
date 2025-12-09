using CManager.Business.Interfaces;
using CManager.Business.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace CManager.Presentation.ConsoleApp.Controllers
{
    public class MenuController
    {
        //create a private field of _customerService by its interface

        private readonly ICustomerService _customerService = new CustomerService();
       
        //method to print menu
        public void PrintMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("CManager - Manage Your Customers");

                Console.WriteLine("Option 1: Create customer");

                Console.WriteLine("Option 2: View all customers");

                Console.WriteLine("Option 0: Exit");

                Console.Write("Choose option: ");

                var menuOption = Console.ReadLine();

                switch (menuOption)
                {
                    case "1":
                        GetCustomerInfo();

                        break;

                    case "2":

                        ViewAllCustomers();

                        break;

                    case "0":
                        return;

                    default:
                        Console.WriteLine("Invalid option");
                        break;
                }

            }
        }

        //method to get user info and create a new customer
        public void GetCustomerInfo()

        {

            Console.Clear();
            Console.WriteLine("Create customer");

            Console.Write("First name:  ");
            var firstName = Console.ReadLine()!;

            Console.Write("Last name:  ");
            var lastName = Console.ReadLine()!;

            Console.Write("Email:  ");
            var email = Console.ReadLine()!;

            Console.Write("Telephone:  ");
            var telephone = Console.ReadLine()!;

            Console.Write("Street addres:  ");
            var streetAddres = Console.ReadLine()!;

            Console.Write("Postal code:  ");
            var postalCode = Console.ReadLine()!;

            Console.Write("City:  ");
            var city = Console.ReadLine()!;

            _customerService.CreateCustomer(firstName, lastName, email, telephone, postalCode, streetAddres, city);
            
          
            Console.WriteLine("Customer created!");
            Console.WriteLine($"Name:  {firstName} Lastname: {lastName}");
           
            OutputDialog("Press any key to continue");
        }

        //method to print all customers
        private void ViewAllCustomers()
        {
            Console.Clear();
            Console.WriteLine("All customers: ");

            var customers = _customerService.GetAllCustomers();

            foreach (var customer in customers)
            {
                Console.WriteLine($"Name: {customer.FirstName} {customer.LastName}");
                Console.WriteLine($"Email: {customer.Email}");
                Console.WriteLine($"Telephone: {customer.Telephone}");
                Console.WriteLine($"Address: {customer.Addres.StreetAddres} {customer.Addres.PostalCode}");
                Console.WriteLine($"ID: {customer.Id}");
                Console.WriteLine();

            }

            //If list of customers id empty
            if (!customers.Any()) Console.WriteLine("No customers in the list. Please add som customers!");
           
            OutputDialog("Press any key to continue");

        }


        private void OutputDialog(string message)
        {
            Console.WriteLine(message);
            Console.ReadKey();

        }


    }
}
