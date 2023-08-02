namespace TheAtlanticBank.UInterface;

public interface IAuthSection
{
    /// <summary>
    /// Display user authentication menu
    /// </summary>
    void DisplayAuthMenu();

    /// <summary>
    /// Lets a user log into his/her account
    /// </summary>
    void Login();

    /// <summary>
    /// Lets a user register
    /// </summary>
    void Register();
}