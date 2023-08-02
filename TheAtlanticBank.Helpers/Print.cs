using Figgle;
using static System.Console;
using System.Collections.Generic;
using TheAtlanticBank.Entities;
using TheAtlanticBank.Data;

namespace TheAtlanticBank.Helpers;

public class Print
{
    public static string dash { get { return "-"; }}

    /// <summary>
    /// Print bank logo
    /// </summary>
    public static void PrintLogo()
    {
        Clear();
        WriteLine(FiggleFonts.Ogre.Render("TheAtlanticBank"));
        WriteLine("\n\n");
    }

    /// <summary>
    /// Print details of all user accounts
    /// </summary>
    /// <param name="accounts"></param>
    public static void PrintDetails(List<Account> accounts)
    {
        int sn = 0;

        Dash(dash);
        WriteLine();
        WriteLine(format: "{0, -3} | {1, -15} | {2, -40} | {3, -15} | {4, -15} |", "S/N", "FULL NAME", "ACCOUNT NUMBER", "ACCOUNT TYPE", "ACCOUNT BAL");
        foreach (Account account in accounts)
        {
            WriteLine(format: "{0, -3} | {1, -15} | {2, -40} | {3, -15} | {4, -15} |", ++sn, account.AccountName, account.AccountNumber, account.AccountType, account.Balance);
        }
        Dash(dash);
        WriteLine();
    }

    /// <summary>
    /// Print details of all user transactions
    /// </summary>
    /// <param name="account"></param>
    /// <param name="transactions"></param>
    public static void PrintTransactionsDetails(Account account, List<Transaction> transactions)
    {
        int sn = 0;

        Dash(dash);
        WriteLine();
        WriteLine(format: "{0, -3} | {1, -15} | {2, -40} | {3, -15} | {4, -15} |", "S/N", "DATE", "DESCRIPTION", "AMOUNT", "BALANCE");
        foreach (Transaction transaction in transactions)
        {
            WriteLine(format: "{0, -3} | {1, -15} | {2, -40} | {3, -15} | {4, -15} |", ++sn, transaction.DateOfTransaction, transaction.Description, transaction.Amount, transaction.Balance);
        }
        Dash(dash);
        WriteLine();   
    }

    /// <summary>
    /// Print dashes
    /// </summary>
    /// <param name="dash"></param>
    public static void Dash(string dash)
    {
        for(int i = 0; i < 102; i++)
        {
            Write(dash);
        }
    }

    /// <summary>
    /// Get greeting using current local time
    /// </summary>
    /// <returns></returns>
    public static string GetGreeting()
    {
        var now = DateTime.Now;
        var greeting = string.Empty;

        if (now.Hour < 12)
            greeting = "morning";
        else if (now.Hour < 17)
            greeting = "afternoon";
        else if (now.Hour < 24)
            greeting = "evening";

        return greeting;
    }

}