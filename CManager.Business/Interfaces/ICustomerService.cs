using CManager.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace CManager.Business.Interfaces
{
    //Interface to CustomerService. 
    public interface ICustomerService
    {
        //Create a new customer 
        void CreateCustomer(string firstName, string lastName, string email, string telephone, string streetAddres, string postalCode, string city);

        //Get all customers from list
        List<Customer> GetAllCustomers();

        //Get specific customer from list
        Customer GetCustomerById(Guid Id);

        //Remove specific customer from list
        void RemoveCustomer(Guid Id);
        
    }
}
