using CManager.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace CManager.Business.Interfaces
{
    public interface ICustomerRepository  //Add more methods - CRUD?


    {
        //method to get all customers
        List<Customer> GetAllCustomers();

        //method to save customer to file
        bool SaveCustomers(List<Customer> customers);

    }
}
