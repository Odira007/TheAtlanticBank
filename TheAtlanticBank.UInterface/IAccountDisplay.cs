using TheAtlanticBank.Entities;

namespace TheAtlanticBank.UInterface;

public interface IAccountDisplay
{
    /// <summary>
    /// Display the user's dashboard
    /// </summary>
    void Dashboard();

    /// <summary>
    /// Lets a user view and use a single account
    /// </summary>
    /// <param name="account"></param>
    void DisplaySingleAccount(Account account);

    /// <summary>
    /// Display all user accounts
    /// </summary>
    /// <param name="customer"></param>
    void DisplayAccounts(Customer customer);

    /// <summary>
    /// Display create account menu
    /// </summary>
    /// <param name="customer"></param>
    void CreateAccountForm(Customer customer);

    /// <summary>
    /// Display deposit menu
    /// </summary>
    /// <param name="account"></param>
    void DepositForm(Account account);

    /// <summary>
    /// Display withdrawal menu
    /// </summary>
    /// <param name="account"></param>
    void WithdrawalForm(Account account);

    /// <summary>
    /// Display transfer menu
    /// </summary>
    /// <param name="account"></param>
    void TransferForm(Account account);

    /// <summary>
    /// Get statement of account
    /// </summary>
    /// <param name="account"></param>
    void GetBankStatement(Account account);

    /// <summary>
    /// Get account balance
    /// </summary>
    /// <param name="account"></param>
    void DisplayAccountBalance(Account account);
}