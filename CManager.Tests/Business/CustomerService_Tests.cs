using CManager.Business.Interfaces;
using CManager.Business.Services;
using CManager.Domain.Models;
using CManager.Infrastructure.Repositories;
using NSubstitute;


namespace CManager.Tests.Business
{
    public class CustomerService_Tests
    {
        [Fact]
        public void CreateCustomer_ShouldReturnFalse_WhenEmailAlreadyExists()
        {
            //ARRANGE

            //create a mock for ICustomerRepository

            var mockRepository = Substitute.For<ICustomerRepository>();

            //create instance of CustomerService with mock repository

            var customerService = new CustomerService(mockRepository);

            string existingEmail = "test@example.com";

            //!!---------->OBS DETTA STYCKET SKREV OCH FÖRKLARADE AI ÅT MIG<-----------!!
            //create new list with one customer and the existing email, return this list when GetAllCustomers is called

            var existingCustomers = new List<Customer> { new Customer { Email = existingEmail } };
            mockRepository.GetAllCustomers().Returns(existingCustomers);
            //__________________________________________________________________________________


            //ACT

            //create a customer with existingEmail and try to register again
            
            var result = customerService.CreateCustomer("Jeanette", "Samuelsson", existingEmail, "07707077070", "Streetname", "123", "City");

            //ASSERT
            
            Assert.False(result);

        }

        

    }
    }
