using TheAtlanticBank.Common;

namespace TheAtlanticBank.Entities;

public class Account
{
    public Account(int accountId, string accountName, string accountNumber, AccountType accountType, int customerId)
    {
        AccountId = accountId;
        CustomerId = customerId;
        AccountName = accountName;
        AccountNumber = accountNumber;
        AccountType = accountType;
        DateOfCreation = DateTime.Now.ToString("MM/dd/yyyy");
    }
    public int AccountId { get; set; }
    public int CustomerId { get; set; }
    public string AccountNumber { get; set; }
    public string AccountName { get; set;}
    public AccountType AccountType { get; set; }
    public string DateOfCreation { get; set; }
    public decimal Balance { get; set; }
    public readonly decimal MinBalance = 1000.00M;
}