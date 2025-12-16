using CManager.Business.Interfaces;
using CManager.Domain.Models;
using System.Xml.Linq;

namespace CManager.Business.Services
{
    public class CustomerService : ICustomerService

    {
        private readonly ICustomerRepository _customerRepository;

        //DI
        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public bool CreateCustomer(string firstName, string lastName, string email, string telephone, string streetAddres, string postalCode, string city)
        {

            //create customer and add to list

            Customer customer = new Customer
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                Telephone = telephone,
                Id = Guid.NewGuid(),
                Addres = new AddresModel
                {
                    StreetAddres = streetAddres,
                    PostalCode = postalCode,
                    City = city
                }
            };

            //get list and add new customer to list

            var customers = _customerRepository.GetAllCustomers();

            customers.Add(customer);

            //save bool true or false
            var result = _customerRepository.SaveCustomers(customers);

            return result;

        }

        //Method to get all customers from list
        public IEnumerable<Customer> GetAllCustomers(out bool hasError)
        {
            hasError = false;

            try
            {
                var customers = _customerRepository.GetAllCustomers();
                return customers;
            }
            catch (Exception)
            {
                hasError = true;
                return [];
            }
        }

        
        //Get customer by email
        public Customer GetCustomerByEmail(string email)
        {
            var customers = _customerRepository.GetAllCustomers();

            //search for specific email and return that customer

            var customer = customers.FirstOrDefault( c => c.Email.Equals(email, StringComparison.OrdinalIgnoreCase));

           
            if (customer is null)
            {
                throw new KeyNotFoundException($"The customer with email {email} does not exist.");
            }
            else return customer;
        }



        //Remove specific customer from list by email
        public bool RemoveCustomerByEmail(string email)
        {
            try
            {
                var customers = _customerRepository.GetAllCustomers();

                //search for specific email and remove that customer

                var customerToRemove = customers.FirstOrDefault(c =>
                    c.Email.Equals(email, StringComparison.OrdinalIgnoreCase)
                );

                if (customerToRemove is null)
                {
                    return false;
                }

                customers.Remove(customerToRemove);

                //save list

                return _customerRepository.SaveCustomers(customers);
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}