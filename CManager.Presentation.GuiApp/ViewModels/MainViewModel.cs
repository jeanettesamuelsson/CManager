using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection; 


namespace CManager.Presentation.GuiApp.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        private readonly IServiceProvider _serviceProvider;

        [ObservableProperty]
        private ObservableObject _currentViewModel = null!;


        // constructor
        public MainViewModel(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;

            // set front page to HomeViewModel

            CurrentViewModel = _serviceProvider.GetRequiredService<HomeViewModel>();
        }
    

        // Commands to navigate between views
        [RelayCommand]
        private void NavigateToCustomerList()
        {
            CurrentViewModel = _serviceProvider.GetRequiredService<CustomerListViewModel>();
        }

        [RelayCommand]
        private void NavigateToCustomerAdd()
        {
            CurrentViewModel = _serviceProvider.GetRequiredService<CustomerAddViewModel>();
        }

        [RelayCommand]
        private void NavigateToHome()
        {
            CurrentViewModel = _serviceProvider.GetRequiredService<HomeViewModel>();
        }
    }

}
