using TheAtlanticBank.Entities;

namespace TheAtlanticBank.Core.Interfaces;

public interface ICustomerService
{
    /// <summary>
    /// Create a new customer
    /// </summary>
    void NewCustomer(string firstName, string lastName, string emailAddress, string password);
}