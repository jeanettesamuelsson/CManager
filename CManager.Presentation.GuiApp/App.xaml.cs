
using System.Windows;
using CManager.Business.Interfaces;
using CManager.Infrastructure.Repositories; 
using CManager.Business.Services;           
using CManager.Presentation.GuiApp.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using CManager.Presentation.GuiApp.Views;


namespace CManager.Presentation.GuiApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private IHost _host;

        public App()
        {
            _host = Host.CreateDefaultBuilder()
                .ConfigureServices(services =>
                {

                    services.AddSingleton<ICustomerRepository, CustomerRepository>();
                    services.AddTransient<ICustomerService, CustomerService>();

                    services.AddTransient<HomeViewModel>();
                    services.AddTransient<CustomerListViewModel>();
                    services.AddTransient<CustomerAddViewModel>();
                    services.AddTransient<CustomerDetailsViewModel>();

                    services.AddTransient<HomeView>();
                    services.AddTransient<CustomerListView>();
                    services.AddTransient<CustomerAddView>();
                    services.AddTransient<CustomerDetailsView>();

                    services.AddSingleton<MainViewModel>();
                    services.AddSingleton<MainWindow>();

                })
                .Build();

        }



        protected override void OnStartup(StartupEventArgs e)
        {
            var mainWindow = _host.Services.GetRequiredService<MainWindow>();
            mainWindow.Show();
        }

    }

}
    



