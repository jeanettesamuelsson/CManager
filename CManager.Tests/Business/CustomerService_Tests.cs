using CManager.Business.Interfaces;
using CManager.Business.Services;
using CManager.Domain.Models;
using NSubstitute;
using NSubstitute.Core;
using NSubstitute.ExceptionExtensions;


namespace CManager.Tests.Business
{
    public class CustomerService_Tests
    {
        //CreateCustomer - Tests
        [Fact]
        public void CreateCustomer_ShouldReturnFalse_WhenEmailAlreadyExists()
        {
            //!!-->OBS I DETTA TESTET TOG JAG HJÄLP AV AI, egna kommentarer för att visa förståelse<--!!
            //De andra testen skrev jag själv

            //ARRANGE

            //create a mock for ICustomerRepository

            var mockRepository = Substitute.For<ICustomerRepository>();

            //create instance of CustomerService with mock repository

            var customerService = new CustomerService(mockRepository);

            string existingEmail = "test@example.com";


            //create new list with one customer and the existing email, return this list when GetAllCustomers is called

            var existingCustomers = new List<Customer> { new Customer { Email = existingEmail } };

            mockRepository.GetAllCustomers().Returns(existingCustomers);

            //ACT

            //create a customer with existingEmail and try to register again

            var result = customerService.CreateCustomer("Jeanette", "Samuelsson", existingEmail, "07707077070", "Streetname", "123", "City");

            //ASSERT

            //check that result is false since email already exists

            Assert.False(result);

            //check that SaveCustomers was never called 

            mockRepository.DidNotReceive().SaveCustomers(Arg.Any<List<Customer>>());

        }

        [Fact]

        public void CreateCustomer_ShouldReturnTrue_WhenCustomerCreatedSuccessfully()
        {
            //ARRANGE - create mock for repositor and new instace of customerService

            var mockRepository = Substitute.For<ICustomerRepository>();
            var customerService = new CustomerService(mockRepository);

            //return empty list when GetAllCustomers is called and return true when SaveCustomers is called

            mockRepository.GetAllCustomers().Returns(new List<Customer>());
            mockRepository.SaveCustomers(Arg.Any<List<Customer>>()).Returns(true);

            //ACT - create a customer

            var result = customerService.CreateCustomer("Jeanette", "Samuelsson", "example@example.com", "07707077070", "Streetname", "123", "City");

            //ASSERT - check if result is true, and that SaveCustomers- method is called once

            Assert.True(result);
            mockRepository.Received(1).SaveCustomers(Arg.Any<List<Customer>>());

        }

        [Fact]

        public void CreateCustomer_ShouldReturnFalse_WhenExceptionIsThrown()
        {
            //ARRANGE - create mock repository and customer service instance
            var mockRepository = Substitute.For<ICustomerRepository>();
            var customerService = new CustomerService(mockRepository);

            //throw exception when GetAllCustomers is called
            mockRepository.GetAllCustomers().Throws(new Exception());

            //ACT - create customer

            var result = customerService.CreateCustomer("Jeanette", "Samuelsson", "example@example.com", "07707077070", "Streetname", "123", "City");

            //ASSERT - check if result is false and that SaveCustomers - method is never called

            Assert.False(result);
            mockRepository.DidNotReceive().SaveCustomers(Arg.Any<List<Customer>>());
        }


        //GetAllCustomers - Tests

        [Fact]

        public void GetAllCustomers_ShouldReturnListOfCustomers_WhenSuccessful()
        {
            //ARRANGE - create mock repository and customer service instance

            var mockRepository = Substitute.For<ICustomerRepository>();
            var customerService = new CustomerService(mockRepository);

            //create list of a customers to return when GetAllCustomers is called

            var customers = new List<Customer>
            {
                new Customer { FirstName = "Jeanette", LastName = "Samuelsson" }
            };

            mockRepository.GetAllCustomers().Returns(customers);

            // ACT 

            var result = customerService.GetAllCustomers(out bool hasError);

            // ASSERT - check if result is equal to the user created and hasError is false

            Assert.Equal(customers, result);
            Assert.False(hasError);

        }

        
    }

}
