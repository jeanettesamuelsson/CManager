using CManager.Business.Interfaces;
using CManager.Business.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using CManager.Presentation.ConsoleApp.Validators;
using CManager.Presentation.ConsoleApp.Interfaces;

namespace CManager.Presentation.ConsoleApp.Controllers
{
    public class MenuController
    {
        //------------>Private fields. Implement Dependency Injection here!<---------------

        //create a private field of _customerService by its interface

        private readonly ICustomerService _customerService = new CustomerService();

        //create a private field of _userInputValidator by its interface

        private readonly IUserInputValidator _userInputValidator = new UserInputValidator();


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
        //Create a new method to ValidateInput(input, validationMethod)
        // !!!!!!!!!!!!---------
        public void GetCustomerInfo()

        {
            string firstName;
            string lastName;
            string email;
            string telephone;
            //Add validation for addres
            bool isValid;

            Console.Clear();
            Console.WriteLine("Create customer");


            //loop to validate first name
            do
            {
                Console.Write("First name:  ");

                firstName = Console.ReadLine()!;

                //return true if name is valid
                isValid = _userInputValidator.ValidateName(firstName);

                if (!isValid)
                {
                    Console.Clear();
                    Console.WriteLine("Invalid name! Please try again.");
                }

                //loop while isValid is false
            } while (!isValid);


            //loop to validate last name
            do
            {
                Console.Write("Last name:  ");

                lastName = Console.ReadLine()!;

                //return true if name is valid
                isValid = _userInputValidator.ValidateName(lastName);

                if (!isValid)
                {
                    Console.Clear();
                    Console.WriteLine("Invalid name! Please try again.");
                }

                //loop while isValid is false
            } while (!isValid);


            //loop to validate email
            do
            {
                Console.Write("Email:  ");

                email = Console.ReadLine()!;

                //return true if email is valid
                isValid = _userInputValidator.ValidateEmail(email);

                if (!isValid)
                {
                    Console.Clear();
                    Console.WriteLine("Invalid email! Please try again.");
                }

                //loop while isValid is false

            } while (!isValid);


            //loop to validate telephone
            do
            {
                Console.Write("Telephone number:  ");

                telephone = Console.ReadLine()!;

                //return true if email is valid
                isValid = _userInputValidator.ValidateTelephone(telephone);

                if (!isValid)
                {
                    Console.Clear();
                    Console.WriteLine("Invalid number! Please try again.");
                }

                //loop while isValid is false

            } while (!isValid);


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
