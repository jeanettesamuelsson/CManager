using CManager.Business.Interfaces;
using CManager.Domain;
using System.Collections.Generic;
using System.Reflection;

namespace CManager.Business.Services
{
    public class CustomerService : ICustomerService

    {
        //Create readonly list of customers 

        readonly List<Customer> _customers = [];

        public bool CreateCustomer(string firstName, string lastName, string email, string telephone, string address) 
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
                    StreetAdress = streetAddres,
                    PostalCode = postalCode,
                    City = city
                }
            };

            _customers.Add(customer);
        }

        //Method to get all customers from list

        public List<Customer> GetAllCustomers()
        {
            return _customers;
        }

        //Get customer by ID
        public Customer? GetCustomerById(Guid Id)
        {
            //search for specific id and return customer
            Customer? customer = _customers.FirstOrDefault(c => c.Id == Id);

            //return exception if customer do not exist
            if (customer is null)
            {
                throw new KeyNotFoundException($"The customer with Id {Id} does not exist.");
            }
            else return customer;
        }

        //Remove specific customer from list

        public bool RemoveCustomer(Guid Id)
        {
            try
            {
                //call method GetCustomerById, returns the customer 
                Customer? toRemove = GetCustomerById(Id);

                // Only attempt to remove if toRemove is not null
                if (toRemove is not null)
                {
                    bool wasRemoved = _customers.Remove(toRemove);
                    return wasRemoved;
                }
                return false;
            }
            catch (KeyNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

    }
}
