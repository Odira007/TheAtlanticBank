using TheAtlanticBank.Data;
using TheAtlanticBank.Entities;
using TheAtlanticBank.Core.Interfaces;

namespace TheAtlanticBank.Core.Services;

public class CustomerService : ICustomerService
{
    public static int IdCount { get; set; }
    
    public void NewCustomer(string firstName, string lastName, string emailAddress, string password)
    {
        IdCount++;

        var customer = new Customer(IdCount, firstName, lastName, emailAddress, password);

        DataStore.customers.Add(customer);
    }
}
