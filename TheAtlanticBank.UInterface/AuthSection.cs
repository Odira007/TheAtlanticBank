using TheAtlanticBank.Core.Authentication;
using TheAtlanticBank.Core.Interfaces;
using TheAtlanticBank.Helpers;
using static System.Console;
using TheAtlanticBank.Common;

namespace TheAtlanticBank.UInterface;

public class AuthSection : IAuthSection
{
    private readonly ICustomerService _customerService;
    public readonly IAccountDisplay _accountDisplay;
    public AuthSection(ICustomerService customerService, IAccountDisplay accountDisplay)
    {
        _customerService = customerService;
        _accountDisplay = accountDisplay;
    }
    public AuthSection() {}

    public void DisplayAuthMenu()
    {
        WriteLine($"a. Login{Environment.NewLine}b. Create Account{Environment.NewLine}c. Exit");
        WriteLine();

        string reply = ReadLine();

        if (reply == "a")
        {
            WriteLine();
            Login();
        }
        else if (reply == "b")
        {
            WriteLine();
            Register();
        }
        else if (reply == "c")
        {
            Environment.Exit(0);
        }
    }

    public void Login()
    {
        int attempts = 0;

        while (attempts < 3)
        {
            Write("Email Address: ");
            string email = ReadLine();
            
            Write("Password: ");
            string password = Validate.GetPasswordMask();

            Write("Loading your banking experience");
            LoadEffect.Load();
            if (Authenticate.Login(email, password)) break;

            WriteLine();
            WriteLine("Invalid email or password");
            attempts++;
        }
    }

    public void Register()
        {
            string firstName = "", lastName = "", email = "", password = "", confirmPassword = "";
            WriteLine("Press q to quit at any time");
            
            while (true)
            {
                Write("First name: ");
                firstName = ReadLine();

                if (firstName.ToLower() == "q") return;
              
                if(!Validate.Name(firstName))
                {
                    WriteLine("Your name must start with an uppercase letter have a maximum of 20 characters");
                    continue;
                }
                break;
            }

            while (true)
            {
                Write("Last name: ");
                lastName = ReadLine();

                if (lastName.ToLower() == "q") return;

                if(!Validate.Name(lastName))
                {
                    WriteLine("Your name must start with an uppercase letter have a maximum of 20 characters");
                    continue;
                }
                break;
            }

            while (true)
            {
                Write("Email: ");
                email = ReadLine();

                if (email.ToLower() == "q") return;

                if(!Validate.Email(email))
                {
                    WriteLine("Your email was input in the wrong format");
                    continue;
                }
                break;
            }

            while (true)
            {
                Write("Password: ");
                password = Validate.GetPasswordMask();

                if (password.ToLower() == "q") return;

                if(!Validate.Password(password))
                {
                    WriteLine("Your email must be at least 6 characters long, must" + " " +
                    "contain alphanumeric characters and at least one special character");
                    continue;
                }
                break;
            }

            while (true)
            {
                Write("Confirm Password: ");
                confirmPassword = Validate.GetPasswordMask();

                if (confirmPassword.ToLower() == "q") return;

                if(!Validate.ConfirmPassword(password, confirmPassword))
                {
                    WriteLine("Passwords do not match!");
                    continue;
                }
                break;
            }
            WriteLine();
            
            _customerService.NewCustomer(firstName, lastName, email, password);
            Authenticate.Login(email, password);
            _accountDisplay.CreateAccountForm(Authenticate.customer);
        }
}