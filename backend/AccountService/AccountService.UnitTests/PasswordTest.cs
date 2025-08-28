using AccountService.Domain;

public class PasswordTest
{
    [Theory]
    [InlineData("Test1234")]
    [InlineData("1234Test")]
    [InlineData("12TEst34")]
    public void WithValidValue(string value)
    {
        var password = new Password(value);
        Assert.Equal(password.Valor, value);
    }


    [Theory]
    [InlineData("")]
    [InlineData("Test123")]
    [InlineData("1234test")]
    [InlineData("12TEST34")]
    public void WithInvalidValue(string value)
    {
        var error = Assert.Throws<DomainError>(() => new Password(value));
        Assert.Equal("Invalid password", error.Message);
    }
}