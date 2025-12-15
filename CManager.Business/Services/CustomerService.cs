using CManager.Business.Interfaces;
using CManager.Domain;
using System.Collections.Generic;
using System.Reflection;

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

       
        
        //Get customer by ID
        public Customer GetCustomerById(Guid Id)
        {
            var customers = _customerRepository.GetAllCustomers();

            //search for specific id and return customer

            var customer = customers.FirstOrDefault(c => c.Id == Id);

            //return exception if customer do not exist

            if (customer is null)
            {
                throw new KeyNotFoundException($"The customer with Id {Id} does not exist.");
            }
            else return customer;
        }

        //Remove specific customer from list by ID

        public void RemoveCustomer(Guid Id)
        {
            var customers = _customerRepository.GetAllCustomers();

            //create new variable of customer to remove,
            //use GetCustomerByID to throw exception if user do not exist

            Customer toRemove = GetCustomerById(Id);
            customers.Remove(toRemove);


        }
    }
}