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

        public void CreateCustomer(string firstName, string lastName, string email, string telephone, string streetAddres, string postalCode, string city)
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

            _customers.Add(customer);

        }

        //Method to get all customers from list

        public List<Customer> GetAllCustomers()
        {
            return _customers;
        }

        //Get customer by ID
        public Customer GetCustomerById(Guid Id)
        {
            //search for specific id and return customer

            Customer customer = _customers.FirstOrDefault(c => c.Id == Id);

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
            //create new variable of customer to remove,
            //use GetCustomerByID to throw exception if user do not exist

            Customer toRemove = GetCustomerById(Id);
            _customers.Remove(toRemove);


        }
    }
}