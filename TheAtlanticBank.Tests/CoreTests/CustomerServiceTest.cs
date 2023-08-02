using Xunit;
using TheAtlanticBank.Entities;
using TheAtlanticBank.Core.Services;

namespace TheAtlanticBank.Tests.CoreTests;

public class CustomerServiceTest
{
    [Fact]
    public void CreateCustomerTest()
    {
        // Arrange
        var customerService = new CustomerService();
        var expected = new Customer(1, "Odira", "Ikewelugo", "odiraikewelugo@gmail.com", "#&*1tsme");

        // Act
        var actual = customerService.NewCustomer(expected.FirstName, expected.LastName, expected.EmailAddress, expected.Password);

        //  Assert
        Assert.Equal(expected, actual);
    }
}