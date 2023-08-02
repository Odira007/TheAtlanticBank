using TheAtlanticBank.Data;
using TheAtlanticBank.Entities;
using System.Linq;


namespace TheAtlanticBank.Core.Authentication;

public class Authenticate
{
    public static Customer customer { get; set; }

    /// <summary>
    /// Authenticate a user's login
    /// </summary>
    /// <returns>Returns true if authentication details pass, else false</returns>
    public static bool Login(string email, string password)
    {
        Customer user = DataStore.customers.FirstOrDefault(c => c.EmailAddress == email);
        if (user == null)
        {
            return false;
        }
        customer = user;
        return true;
    }

    /// <summary>
    /// Let's a user log out
    /// </summary>
    public static void Logout()
    {
        customer = null;
    }
}