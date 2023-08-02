using System.Net.Mail;
using System.Text.RegularExpressions;
using TheAtlanticBank.Entities;
using TheAtlanticBank.Data;
using static System.Console;

namespace TheAtlanticBank.Helpers;

public class Validate
{
    /// <summary>
    /// Check for valid name entry
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public static bool Name(string name) => new Regex(@"^[A-Z]{1}([a-z]|[A-Z]){1,19}$").IsMatch(name) ? true : false;

    /// <summary>
    /// Check for valid password entry
    /// </summary>
    /// <param name="password"></param>
    /// <returns></returns>
    public static bool Password(string password) => new Regex(@"^(?=.*\d)(?=.*[a-zA-Z])(?=.*[!@#$%""^&*()_+\-=\[\]{};':\\|,.<>\/?]).{6,}$").IsMatch(password) ? true : false; 

    /// <summary>
    /// Confirm password
    /// </summary>
    /// <param name="password"></param>
    /// <param name="confirmPassword"></param>
    /// <returns></returns>
    public static bool ConfirmPassword(string password, string confirmPassword) => password == confirmPassword ? true : false;

    /// <summary>
    /// Check for valid email entry
    /// </summary>
    /// <param name="email"></param>
    /// <returns></returns>
    public static bool Email(string email)
    {
        try
        {
            var emailCheck = new MailAddress(email);
            return true;
        }
        catch (FormatException)
        {
            return false;
        }  
    }

    /// <summary>
    /// Check if an account exists
    /// </summary>
    /// <param name="accountNumber"></param>
    /// <param name="message"></param>
    /// <returns></returns>
    public static Account FindAccount(string accountNumber, out string message)
    {  
        if(!Regex.IsMatch(accountNumber, @"\d{10}"))
        {
            message = "Invalid input";
            return null;
        }
        var account = DataStore.accounts.First(acc => acc.AccountNumber == accountNumber);

        if (account == null)
        {
            message = "Beneficiary does not exist";
        }
        
        message = string.Empty;
        return account;
    }

    /// <summary>
    /// Hide password entry visibility
    /// </summary>
    /// <returns></returns>
    public static string GetPasswordMask()
    {
        var pass = string.Empty;
        ConsoleKey key;
        do
        {
            var keyInfo = ReadKey(intercept: true);
            key = keyInfo.Key;

            if (key == ConsoleKey.Backspace && pass.Length > 0)
            {
                Write("\b \b");
                pass = pass.Substring(0, pass.Length - 1);
            }
            else if (!char.IsControl(keyInfo.KeyChar))
            {
                Write("*");
                pass += keyInfo.KeyChar;
            }
        } 
        while (key != ConsoleKey.Enter);
        WriteLine();

        return pass;
    }
}
