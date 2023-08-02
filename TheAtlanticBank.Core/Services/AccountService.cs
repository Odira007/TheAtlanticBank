using TheAtlanticBank.Data;
using TheAtlanticBank.Common;
using TheAtlanticBank.Entities;
using TheAtlanticBank.Core.Interfaces;
using TheAtlanticBank.Core.Authentication;

namespace TheAtlanticBank.Core.Services;

public class AccountService : IAccountService
{
    public static int IdCount { get; set; }
    private readonly ITransactionService _transactionService;
    public AccountService(ITransactionService transactionService)
    {
        _transactionService = transactionService;
    }

    public void NewAccount(char type)
    {
        var customer = Authenticate.customer;
        IdCount++;
        string accountNumber = "21";
        AccountType accountType = type == 'a' ? AccountType.Savings : AccountType.Current;
        Random rand = new Random();
        for (int i = 0; i < 8; i++)
        {
            int randomNum = rand.Next(10);
            accountNumber += randomNum;
        }
        
        var account = new Account(IdCount, customer.FullName, accountNumber, accountType, customer.Id);

        DataStore.accounts.Add(account);
    }

    public void Deposit(int accountId, decimal amount)
    {
        if (amount == 0) throw new Exception("Why?");

        var account = DataStore.accounts.First(acc => acc.AccountId == accountId);
        account.Balance += amount;
        var description = $"Deposit by {Authenticate.customer.FullName}";
        _transactionService.CreateTransaction(description, amount, accountId);
    }

    public void Withdraw(int accountId, decimal amount)
    {
        var account = DataStore.accounts.First(acc => acc.AccountId == accountId);
    
        if (amount < 0) throw new FormatException("Invalid amount");
        if (amount > account.Balance) throw new InvalidOperationException("Insufficient Funds!");
        if (account.AccountType == AccountType.Savings)
        {
            if (account.Balance <= account.MinBalance)
            {
                throw new InvalidOperationException("Insufficient Funds");
            }
            account.Balance -= amount;
        }
        account.Balance -= amount;
        var description = $"Withdrawal by {Authenticate.customer.FullName}";
        _transactionService.CreateTransaction(description, amount, accountId);
    }

    public void Transfer(int sourceId, int beneficiaryId, decimal amount)
    {
        if (amount < 0) throw new FormatException("Invalid amount");
        
        var sourceAccount = DataStore.accounts.First(bankAccount => bankAccount.AccountId == sourceId);
        var destinationAccount = DataStore.accounts.First(bankAccount => bankAccount.AccountId == beneficiaryId);

        if (amount > sourceAccount.Balance) throw new InvalidOperationException("Insufficient Funds!");
        if (sourceAccount.AccountType == AccountType.Savings)
        {
            if (sourceAccount.Balance <= sourceAccount.MinBalance)
            {
                throw new InvalidOperationException("Insufficient Funds");
            }
            sourceAccount.Balance -= amount;
            destinationAccount.Balance += amount;
        }
        sourceAccount.Balance -= amount;
        destinationAccount.Balance += amount;

        var description = $"Transfer by {Authenticate.customer.FullName}";
        _transactionService.CreateTransaction(description, amount, sourceId);
        _transactionService.CreateTransaction(description, amount, beneficiaryId);
    }

    public Account Get(int id) => DataStore.accounts.First(acc => acc.AccountId == id);

    public List<Account> GetAccountsById(int accountId) => 
                    DataStore.accounts.Where(acc => acc.CustomerId == accountId).ToList();
}