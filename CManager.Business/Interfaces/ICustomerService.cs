using CManager.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace CManager.Business.Interfaces
{
    //Interface to CustomerService. No logic here 
    public interface ICustomerService
    {
        //Create a new customer and a unique ID using GUID helper class
        void CreateCustomer(string firstName, string lastName, string email, string telephone, string address);



        //Get all customers from list

        List<Customer> GetAllCustomers();

        //Get specific customer from list

        Customer GetCustomerByID(Id)
        {

        }

        //Remove specific customer from list
    }
}
