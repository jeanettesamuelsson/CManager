using CManager.Business.Interfaces;
using CManager.Presentation.ConsoleApp.Interfaces;


namespace CManager.Presentation.ConsoleApp.Controllers
{
    public class MenuController
    {
        private readonly ICustomerService _customerService;
        private readonly IUserInputValidator _userInputValidator;

        //dependency injection 
        public MenuController(ICustomerService customerService, IUserInputValidator userInputValidator)
        {
            _customerService = customerService;
            _userInputValidator = userInputValidator;
        }

        //method to print menu
        public void PrintMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("CManager - Manage Your Customers");
                Console.WriteLine("**********************************");

                Console.WriteLine("Option 1: Create customer");

                Console.WriteLine("Option 2: View all customers");

                Console.WriteLine("Option 3: View customer by email-adress");

                Console.WriteLine("Option 4: Remove Customer");

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

                    case "3":
                        ViewCustomerByEmail();
                        break;

                    case "4":
                        RemoveCustomer();
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
        //Create a new method to ValidateInput(input, validationMethod, error message) 

        public void GetCustomerInfo()

        {
            Console.Clear();
            Console.WriteLine("Create customer");

            //use GetValidatedInput method to get all inputs from user

            string firstName = GetValidatedInput("First name", _userInputValidator.ValidateName, "Invalid name! Please try again.");

            string lastName = GetValidatedInput("Last name", _userInputValidator.ValidateName, "Invalid name! Please try again.");

            string email = GetValidatedInput("Email", _userInputValidator.ValidateEmail, "Invalid email! Please try again.");

            string telephone = GetValidatedInput("Telephone number", _userInputValidator.ValidateTelephone, "Invalid number! Please try again.");

            string streetAddres = GetValidatedInput("Street addres", _userInputValidator.ValidateName, "Invalid street addres! Please try again.");

            string postalCode = GetValidatedInput("Postal code", _userInputValidator.ValidatePostalCode, "Invalid postal code! Please try again.");

            string city = GetValidatedInput("City", _userInputValidator.ValidateName, "Invalid city! Please try again.");

           
            //get true or false from CreateCustomer method

            var isCreated = _customerService.CreateCustomer(firstName, lastName, email, telephone, postalCode, streetAddres, city);


            if (isCreated)
            {
                Console.WriteLine("Success!");
                Console.WriteLine($"Customer {firstName} {lastName} is added!");
            }
            else
            {
                Console.WriteLine("A customer with this email already exists. Please try again!");
            }

            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }

        //method to print all customers
        private void ViewAllCustomers()
        {
            Console.Clear();
            Console.WriteLine("All customers: ");

            var customers = _customerService.GetAllCustomers(out bool hasError);

            if (hasError)
            {
                Console.WriteLine("Error. Please try again!");
                return;
            }

            if (!customers.Any())
            {
                Console.WriteLine("List is empty. Please add some customers!");
            }
            else
            {
                foreach (var customer in customers)
                {
                    Console.WriteLine($"Name: {customer.FirstName} {customer.LastName}");
                    Console.WriteLine($"ID: {customer.Id}");
                    Console.WriteLine($"Email: {customer.Email}");
                    Console.WriteLine();

                }
            }

            Console.ReadKey();
        }

        // method to view customer by email
        public void ViewCustomerByEmail()
        {
            Console.Clear();
            Console.Write("Enter email to search for customer: ");

            //get email from user and call GetCustomerByEmail method

            var email = Console.ReadLine()!;
            var customer = _customerService.GetCustomerByEmail(email);

            Console.WriteLine($"Name: {customer.FirstName} {customer.LastName}");
            Console.WriteLine($"ID: {customer.Id}");
            Console.WriteLine($"Email: {customer.Email}");
            Console.WriteLine($"Telephone: {customer.Telephone}");

            if (customer.Addres != null)
            {
                Console.WriteLine($"Addres: {customer.Addres.StreetAddres}, {customer.Addres.PostalCode}, {customer.Addres.City}");
            }

            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }


        //method to remove customer by email,
        //will print a message if customer was removed successfully or not found
        public void RemoveCustomer()
        {
            Console.Clear();
            Console.Write("Enter email of customer to remove: ");
            var email = Console.ReadLine()!;

            //confirmation before deleting

            Console.Write($"Do you want to remove customer with email:  {email}? (y/n): ");
            var confirmation = Console.ReadLine()!.ToLower();

            if (confirmation == "n")
            {
                Console.WriteLine("Operation cancelled. Press any key to continue.");
                Console.ReadKey();
                return;
            }

            if (confirmation == "y")
            {
                //get bool value from RemoveCustomerByEmail method

                var removed = _customerService.RemoveCustomerByEmail(email);
                if (removed)
                {
                    Console.WriteLine("Customer removed successfully.");
                }
                else
                {
                    Console.WriteLine("Customer not found.");
                }

                Console.WriteLine("Press any key to continue");
                Console.ReadKey();
            }
        }

        //method to get validated inut from user
        private string GetValidatedInput(string prompt, Func<string, bool> validationMethod, string errorMessage)
         {
            string userInput;
            bool isValid;

            do
            {
                Console.Write($"{prompt}: ");
                userInput = Console.ReadLine()!;

                //send userInput into validation method

                isValid = validationMethod(userInput);

                if (!isValid)           
                {
                    Console.WriteLine(errorMessage);
                }

            } while (!isValid);

            return userInput;

        }
    }
}
