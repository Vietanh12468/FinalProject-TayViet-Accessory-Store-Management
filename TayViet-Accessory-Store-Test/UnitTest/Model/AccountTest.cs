using FinalProject_TayViet_Accessory_Store_Management.Server.Models;
using Xunit;

public class AccountTests
{
    [Fact]
    public void Login_AccountInactive_ShouldChangeStateToActive()
    {
        // Arrange
        var account = new Account("Test User", "test@example.com", "password", "1234567890", "testuser");

        // Act
        account.Login();

        // Assert
        Assert.Equal("Active", account.state);
    }


    [Fact]
    public void Login_AccountActive_ShouldThrowException()
    {
        // Arrange
        var account = new Account("Test User", "test@example.com", "password", "1234567890", "testuser");
        account.Login();

        // Act & Assert
        Assert.Throws<InvalidOperationException>(() => account.Login());
    }

    [Fact]
    public void Logout_AccountActive_ShouldChangeStateToInactive()
    {
        // Arrange
        var account = new Account("Test User", "test@example.com", "password", "1234567890", "testuser");
        account.Login();

        // Act
        account.Logout();

        // Assert
        Assert.Equal("Inactive", account.state);
    }

    [Fact]
    public void Logout_AccountInactive_ShouldThrowException()
    {
        // Arrange
        var account = new Account("Test User", "test@example.com", "password", "1234567890", "testuser");

        // Act & Assert
        Assert.Throws<InvalidOperationException>(() => account.Logout());
    }
}
