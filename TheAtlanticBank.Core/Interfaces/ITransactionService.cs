using TheAtlanticBank.Entities;

namespace TheAtlanticBank.Core.Interfaces;

public interface ITransactionService
{
    /// <summary>
    /// Creates a new transaction
    /// </summary>
    /// <param name="description"></param>
    /// <param name="amount"></param>
    /// <param name="accountId"></param>
    void CreateTransaction(string description, decimal amount, int accountId);

    /// <summary>
    /// Gets a list of all transactions by a customer
    /// </summary>
    /// <param name="transId"></param>
    /// <returns>List of transactions</returns>
    List<Transaction> BankStatement(int transId);
}