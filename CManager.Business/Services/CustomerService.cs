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

        //Method to create a new customer and a unique ID using GUID helper class

        public void CreateCustomer(string firstName, string lastName, string email, string telephone, string address) 
        {
            Customer customer = new Customer
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email, 
                Telephone = telephone,
                Address = address,
            };

            //Call method GUID to generate a Id


            //Add customer to list

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
                // FORTSÄTT HÄR!!!!
                //
                //
                //
                //
                //
                // call method GetCustomerById, returns the customer 
                //Customer toRemove = GetCustomerById(Id);
                
                //_customers.Remove(toRemove);

                return true;
            }
            catch (KeyNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

    }
}
