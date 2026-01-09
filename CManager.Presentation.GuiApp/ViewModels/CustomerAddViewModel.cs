
using CManager.Business.Interfaces;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;


namespace CManager.Presentation.GuiApp.ViewModels
{
    public partial class CustomerAddViewModel(ICustomerService customerService, IServiceProvider serviceProvider) : ObservableObject
    {
        private readonly IServiceProvider _serviceProvider = serviceProvider;
        private readonly ICustomerService _customerService = customerService;

        [ObservableProperty]
        private string _firstName = string.Empty;

        [ObservableProperty]
        private string _lastName = string.Empty;

        [ObservableProperty]
        private string _email = string.Empty;

        [ObservableProperty]
        private string _phoneNumber = string.Empty;

        [ObservableProperty]
        private string _streetAddres = string.Empty;

        [ObservableProperty]
        private string _postalCode = string.Empty;

        [ObservableProperty]
        private string _city = string.Empty;

        //method to get data from input fields and save new customer

        [RelayCommand]
        private void Save()
        {
            var result = _customerService.CreateCustomer(
                FirstName,
                LastName,
                Email,
                PhoneNumber,
                StreetAddres,
                PostalCode,
                City
                );


            if (result)
            {
                // navigate back to CustomerListView
                var mainViewModel = _serviceProvider.GetRequiredService<MainViewModel>();
                mainViewModel.CurrentViewModel = _serviceProvider.GetRequiredService<CustomerListViewModel>();
            }


        }

        //method to cancel adding a new customer and go back to customerlistview
        [RelayCommand]

        private void Cancel()
        {
            var mainViewModel = _serviceProvider.GetRequiredService<MainViewModel>();
            mainViewModel.CurrentViewModel = _serviceProvider.GetRequiredService<CustomerListViewModel>();
        }
    }

}

