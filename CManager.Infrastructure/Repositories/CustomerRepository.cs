using CManager.Business.Interfaces;
using CManager.Domain.Models;
using CManager.Infrastructure.Serialization;

namespace CManager.Infrastructure.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {

        private readonly string _filePath;
        private readonly string _directoryPath;


        //constructor to set file path and directory path
        public CustomerRepository(string directoryPath = "Data", string fileName = "list.json")
        {
            _directoryPath = directoryPath;
            _filePath = Path.Combine(_directoryPath, fileName);
        }   

        
        //method to get all customers from file
        public List<Customer> GetAllCustomers()
        {
            //return empty list if file does not exist
            if (!File.Exists(_filePath))
            {
                return [];
            }

            try
            {
                var json = File.ReadAllText(_filePath);

                //convert json to c# object 
                var customers = JsonFormatter.Deserialize<List<Customer>>(json);

                //return customers or empty list if null
                return customers ?? [];

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading customers: {ex.Message}");
                throw;
            }

        }


        //method to save all customers to file
        public bool SaveCustomers(List<Customer> customers)
        {
            if (customers == null)
            {
                return false;
            }

            try
            {
                //convert c# object to json
                var json = JsonFormatter.Serialize(customers);

                //create directory path if it does not exist
                if (!Directory.Exists(_directoryPath))
                {
                    Directory.CreateDirectory(_directoryPath);
                }
                //write json to file
                File.WriteAllText(_filePath, json);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving customers: {ex.Message}");
                return false;

            }

        }

        //method to delete customer by email
        public bool DeleteCustomer(string email)
        {
            try
            {   //get customers from file
                var customers = GetAllCustomers();
                var customerToRemove = customers.FirstOrDefault(c => c.Email.Equals(email, StringComparison.OrdinalIgnoreCase));

                //if customer found, remove and save updated list
                if (customerToRemove != null)
                {
                    customers.Remove(customerToRemove);
                    return SaveCustomers(customers);
                }
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting customer: {ex.Message}");
                return false;
            }
        }

    }

}
