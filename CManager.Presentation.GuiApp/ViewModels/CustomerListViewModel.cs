using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Extensions.DependencyInjection;
using CManager.Business.Interfaces;
using CManager.Business.Services;
using System.Collections.ObjectModel;
using CManager.Domain.Models;
using CommunityToolkit.Mvvm.Input;

namespace CManager.Presentation.GuiApp.ViewModels
{
    public partial class CustomerListViewModel: ObservableObject
    {
        private readonly ICustomerService _customerService;
        private readonly IServiceProvider _serviceProvider;

        //create an observable collection for customers

        [ObservableProperty]
        private ObservableCollection<Customer> _customers = [];

        //constructor   
        public CustomerListViewModel(ICustomerService customerService, IServiceProvider serviceProvider)
        {
            _customerService = customerService;
            _serviceProvider = serviceProvider;

            bool hasError;
            var customers = _customerService.GetAllCustomers(out hasError);

            if (!hasError)
            {
                Customers = new ObservableCollection<Customer>(customers);
            }
        }

        
        [RelayCommand]
        private void GoToAddCustomerView()
        {
            var mainViewModel = _serviceProvider.GetRequiredService<MainViewModel>();
            mainViewModel.CurrentViewModel = _serviceProvider.GetRequiredService<CustomerAddViewModel>();
        }

        [RelayCommand]
        private void GoToCustomerDetailsView(Customer customer)
        {
            var mainViewModel = _serviceProvider.GetRequiredService<MainViewModel>();
            mainViewModel.CurrentViewModel = _serviceProvider.GetRequiredService<CustomerDetailsViewModel>();
            
        }

    }
}
