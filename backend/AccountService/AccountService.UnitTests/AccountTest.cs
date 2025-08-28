using AccountService.Domain;

namespace AccountService.UnitTests;

public class AccountTest
{
    private readonly string _Name;
    private readonly string _Document;
    private readonly string _Password;
    private readonly Guid _Id;

    public AccountTest()
    {
        _Name = "Ana Maria Silva";
        _Document = "11144466610";
        _Password = "Test1234";
        _Id = Guid.NewGuid();
    }

    [Fact]
    public void WithValidValues()
    {
        var account = new Account(_Name, _Document, _Password);
        Assert.Equal(_Name, account.Name);
        Assert.Equal(_Document, account.Document);
        Assert.Equal(_Password, account.Password);
        Assert.NotEqual(Guid.Empty, account.Id);
    }

    [Fact]
    public void WithValidValuesAndId()
    {
        var account = new Account(_Id, _Name, _Document, _Password);
        Assert.Equal(_Name, account.Name);
        Assert.Equal(_Document, account.Document);
        Assert.Equal(_Password, account.Password);
        Assert.Equal(_Id, account.Id);
    }

    [Fact]
    public void WithInvalidName()
    {
        var error = Assert.Throws<DomainError>(() => new Account("", _Document, _Password));
        Assert.Equal("Invalid name", error.Message);
    }

    [Fact]
    public void WithInvalidDocument()
    {
        var error = Assert.Throws<DomainError>(() => new Account(_Name, "123", _Password));
        Assert.Equal("Invalid document", error.Message);
    }

    [Fact]
    public void WithInvalidPassword()
    {
        var error = Assert.Throws<DomainError>(() => new Account(_Name, _Document, "123"));
        Assert.Equal("Invalid password", error.Message);
    }
}