using static System.Console;
using TheAtlanticBank.Common;
using TheAtlanticBank.Helpers;
using TheAtlanticBank.Entities;
using TheAtlanticBank.Core.Services;
using TheAtlanticBank.Core.Interfaces;
using TheAtlanticBank.Core.Authentication;

namespace TheAtlanticBank.UInterface;

public class AccountDisplay : IAccountDisplay
{
    private readonly ITransactionService _transactionsService;
    private readonly IAccountService _accountService;
    public AccountDisplay(ITransactionService transactionsService, IAccountService bankAccountService)
    {
        _transactionsService = transactionsService;
        _accountService = bankAccountService;
    }

    public AccountDisplay() {}

    public void Dashboard()
    {
        Print.PrintLogo();

        WriteLine($"Good {Print.GetGreeting()}, How can we help you?{Environment.NewLine}Select an option to continue: ");
        WriteLine("\t1. See my Accounts\n\t2. Create new Account\n\t3. Log out");
        Write("==> ");
        string choice = ReadLine();

        var customer = Authenticate.customer;

        if (choice == "1")
        {
            DisplayAccounts(customer);
        } 
        else if (choice == "2")
        {
            CreateAccountForm(customer);
        }
        else if (choice == "3")
        {
            Authenticate.Logout();
        }
    }
    public void CreateAccountForm(Customer customer)
    {
        WriteLine("Select an account type");
        WriteLine($"\ta. Savings\n\tb. Current");
        Write("==> ");
        char choice = Convert.ToChar(ReadLine());

        if (choice == 'a' || choice == 'b')
        {
            Write("Your account is being created");
            LoadEffect.Load();
            _accountService.NewAccount(choice);
            var account = _accountService.Get(AccountService.IdCount);

            WriteLine();
            WriteLine("Your account was successfully created");
            WriteLine($"\tAccount name: {account.AccountName}\n\tAccount number: {account.AccountNumber}\n\tAccount type: {account.AccountType}");
            WriteLine("Press enter to continue: ");
            ReadLine(); 
            Dashboard();
        }
        else
        {
            WriteLine("Please choose a valid option.");
            CreateAccountForm(customer);
        }
    }

    public void DisplayAccounts(Customer customer)
    {
        var accounts = _accountService.GetAccountsById(customer.Id);

        if (accounts.Count > 0)
        {
            Print.PrintDetails(accounts);

            Write("Select an account to continue: ");
            var answer = int.TryParse(ReadLine(), out int num);

            if (num > 0 && num <= accounts.Count)
            {
                DisplaySingleAccount(accounts[num - 1]);
            }
        }
    }

    public void DisplaySingleAccount(Account account)
    {
        Print.PrintLogo();

        WriteLine($"\tAccount name: {account.AccountName}\n\tAccount number: {account.AccountNumber}\n\tAccount type: {account.AccountType}");
        WriteLine();
        WriteLine("Select an option to continue: ");
        WriteLine("\t1. Deposit\n\t2. Withdraw\n\t3. Send money\n\t4. Bank Statement\n\t5. Get balance\n\t6. Main menu");
        Write("==> ");
        var answer = int.Parse(ReadLine());

        switch(answer)
        {
            case 1:
            DepositForm(account);
            break;
            case 2:
            WithdrawalForm(account);
            break;
            case 3:
            TransferForm(account);
            break;
            case 4:
            GetBankStatement(account);
            break;
            case 5:
            DisplayAccountBalance(account);
            break;
            case 6:
            Dashboard();
            break;
            default:
            WriteLine("Invalid option");
            break;
        }
    }
    public void DepositForm(Account account)
    {
        Write("Amount: ");
        string num = ReadLine();

        if (!decimal.TryParse(num, out decimal amount))
        {
            WriteLine("Invalid amount");
        }
        else
        {
            try
            {
                _accountService.Deposit(account.AccountId, amount);

                Write("Processing deposit transaction");
                LoadEffect.Load();
                WriteLine();

                WriteLine("Deposit Successful");
            }
            catch(Exception ex)
            {
                WriteLine(ex.Message);
            }
        }

        Write("Press enter to continue");
        ReadLine();
        DisplaySingleAccount(account);
    }

    public void WithdrawalForm(Account account)
    {
        Write("Amount: ");
        string num = ReadLine();

        if (!decimal.TryParse(num, out decimal amount))
        {
            WriteLine("Invalid amount");
            ReadLine();
            DisplaySingleAccount(account);
        }
        else
        {
            try
            {
                _accountService.Withdraw(account.AccountId, amount);

                Write("Processing withdrawal transaction");
                LoadEffect.Load();
                WriteLine();

                WriteLine("Withdrawal successful");
            }
            catch(Exception ex)
            {
                WriteLine(ex.Message);
            }
        }
        Write("Press enter to continue");
        ReadLine();
        DisplaySingleAccount(account);
    }
    public void TransferForm(Account account)
    {
        Write("Amount: ");
        string num = ReadLine();

        if (!decimal.TryParse(num, out decimal amount))
        {
            WriteLine("Invalid amount");
            ReadLine();
            DisplaySingleAccount(account);
        }
        Write("Enter beneficiary account: ");
        var accNum = ReadLine();
        var beneficiary = Validate.FindAccount(accNum, out string message);

        if (beneficiary == null)
        {
            WriteLine(message);
            WriteLine("Press enter to continue: ");
            ReadLine();

            DisplaySingleAccount(account);
        }
        else
        {
            try
            {
                _accountService.Transfer(account.AccountId, beneficiary.AccountId, amount);

                Write("Processing transfer");
                LoadEffect.Load();
                WriteLine();

                WriteLine("Transfer Successful");
            }
            catch(Exception ex)
            {
                WriteLine(ex.Message);
            }
        }
        Write("Press enter to continue");
        ReadLine();
        DisplaySingleAccount(account);
    }

    public void DisplayAccountBalance(Account account)
    {
        WriteLine($"Available balance for account {account.AccountNumber}: {account.Balance:C}");

        Write("Press enter to continue");
        ReadLine();
        DisplaySingleAccount(account);
    }

    public void GetBankStatement(Account account)
    {
        Print.PrintLogo();

        var transactions = _transactionsService.BankStatement(account.AccountId);

        if (transactions.Count > 0)
        {
            Print.PrintTransactionsDetails(account, transactions);
        }
        else
        {
            WriteLine("You currently have no transactions");
        }

        Write("Press enter to continue");
        ReadLine();
        DisplaySingleAccount(account);
    }
}
