using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TheAtlanticBank.Core.Interfaces;
using TheAtlanticBank.Core.Services;
using TheAtlanticBank.UInterface;
using System;

namespace TheAtlanticBank
{
    class Program
    {
        static void Main(string[] args)
        {
            var host = Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                    services.AddScoped<ICustomerService, CustomerService>();
                    services.AddScoped<ITransactionService, TransactionService>();
                    services.AddScoped<IAccountService, AccountService>();
                    services.AddScoped<IAccountDisplay, AccountDisplay>();
                    services.AddScoped<IAuthSection, AuthSection>();
                }).Build();

            var userInterface = ActivatorUtilities.CreateInstance<UserInterface>(host.Services);
            userInterface.Start();
        }
    }
}