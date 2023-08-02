using TheAtlanticBank.Core.Authentication;
using TheAtlanticBank.Helpers;
using System.Threading;
using System;
using static System.Console;

namespace TheAtlanticBank.UInterface;

public class UserInterface
{
    private readonly IAuthSection _authSection;
    private readonly IAccountDisplay _accountDisplay;
    public UserInterface(IAuthSection authSection, IAccountDisplay accountDisplay)
    {
        _authSection = authSection;
        _accountDisplay = accountDisplay;
    }

    public void Start()
    {
        while (true)
        {
            while(Authenticate.customer == null)
            {
                Print.PrintLogo();
                _authSection.DisplayAuthMenu();
            }
            _accountDisplay.Dashboard();
        }
    }
}