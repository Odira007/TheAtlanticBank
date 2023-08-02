using TheAtlanticBank.Data;
using TheAtlanticBank.Entities;
using TheAtlanticBank.Core.Authentication;

namespace TheAtlanticBank.Tests.CoreTests;

public class AuthenticateTests
{
    [Fact]
    public void LoginValid()
    {
        // Arrange
        var auth = new Authenticate();
        var c1 = new Customer(1, "Odira", "Ikewelugo", "odiraikewelugo@gmail.com", "#&*1tsme");
        var c2 = new Customer(2, "Chinonso", "Ikewelugo", "chinonsoikewelugo@gmail.com", "Valentine#486728");
        DataStore.customers.Add(c1);
        DataStore.customers.Add(c2);
        var expected = true;

        // Act
        var actual = Authenticate.Login("odiraikewelugo@gmail.com", "#&*1tsme");

        // Assert
        Assert.Equal(expected, actual);
    }
}