using TheAtlanticBank.Entities;

namespace TheAtlanticBank.Core.Interfaces;

public interface IAccountService
{
    /// <summary>
    /// Creates a new bank account
    /// </summary>
    /// <param name="type"></param>
    void NewAccount(char type);

    /// <summary>
    /// Creates a deposit transaction
    /// </summary>
    /// <param name="accountId"></param>
    /// <param name="amount"></param>
    void Deposit(int accountId, decimal amount);

    /// <summary>
    /// Creates a withdrawal transaction
    /// </summary>
    /// <param name="accountId"></param>
    /// <param name="amount"></param>
    void Withdraw(int accountId, decimal amount);

    /// <summary>
    /// Creates a transfer transaction
    /// </summary>
    /// <param name="sourceId"></param>
    /// <param name="beneficiaryId"></param>
    /// <param name="amount"></param>
    void Transfer(int sourceId, int beneficiaryId, decimal amount);

    /// <summary>
    /// Get a single account by its Id
    /// </summary>
    /// <param name="accountId"></param>
    /// <returns></returns>
    Account Get(int accountId);

    /// <summary>
    /// Gets a list of all accounts owned by a user
    /// </summary>
    /// <param name="accountId"></param>
    /// <returns></returns>
    public List<Account> GetAccountsById(int accountId);
}