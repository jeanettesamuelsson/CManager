using CManager.Domain.Models;

namespace CManager.Business.Interfaces
{
    public interface ICustomerRepository  //Add more methods? - CRUD

    {
        //method to get all customers 
        List<Customer> GetAllCustomers();

        //method to save customer to file 
        bool SaveCustomers(List<Customer> customers);

        //method to delete customer
        bool DeleteCustomer(string email);
    }
}
