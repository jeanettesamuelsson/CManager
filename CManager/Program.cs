// -----------------CManager - Inlämningsuppgift C#-------------------
using CManager.Business.Interfaces;
using CManager.Business.Services;
using CManager.Infrastructure.Repositories;
using CManager.Presentation.ConsoleApp.Controllers;
using CManager.Presentation.ConsoleApp.Interfaces;
using CManager.Presentation.ConsoleApp.Validators;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;




//create a generic host builder
var builder = Host.CreateApplicationBuilder(args);

//register services for dependency injection
builder.Services.AddScoped<MenuController>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IUserInputValidator, UserInputValidator>();


var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var serviceProvider = scope.ServiceProvider;
    var controller = serviceProvider.GetRequiredService<MenuController>();
    controller.PrintMenu();
}

