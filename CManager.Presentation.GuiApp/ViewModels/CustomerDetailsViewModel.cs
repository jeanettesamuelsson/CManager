using CManager.Business.Interfaces;
using CManager.Domain.Models;
using CommunityToolkit.Mvvm.ComponentModel;


namespace CManager.Presentation.GuiApp.ViewModels
{
    public partial class CustomerDetailsViewModel : ObservableObject
    {
        [ObservableProperty]

        private Customer? _selectedCustomer;

        public CustomerDetailsViewModel()
        {

        }

    }

}

    