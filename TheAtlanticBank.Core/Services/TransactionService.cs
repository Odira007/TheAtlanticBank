using TheAtlanticBank.Core.Interfaces;
using TheAtlanticBank.Entities;
using TheAtlanticBank.Data;

namespace TheAtlanticBank.Core.Services;

public class TransactionService : ITransactionService
{
    public static int IdCount { get; set; } = 0;

    public void CreateTransaction(string description, decimal amount, int accountId)
    {
        var transaction = new Transaction(IdCount, description, amount, accountId);
        DataStore.transactions.Add(transaction);
        IdCount++;
        var account = DataStore.accounts.First(acc => acc.AccountId == accountId);

        transaction.Balance = account.Balance;
    }

    public List<Transaction> BankStatement(int transId) => 
                DataStore.transactions.Where(trans => trans.AccId == transId).ToList();
}