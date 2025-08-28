using AccountService.Domain;

public class NameTest
{
    [Theory]
    [InlineData("Ana Maria Silva")]
    [InlineData("João da Silva")]
    [InlineData("Maria Souza")]
    public void WithValidValue(string name)
    {
        var nome = new Name(name);
        Assert.Equal(nome.Valor, name);
    }

    [Theory]
    [InlineData("")]
    [InlineData("A")]
    [InlineData(" ")]
    public void WithInvalidValue(string name)
    {
        var error = Assert.Throws<DomainError>(() => new Name(name));
        Assert.Equal("Invalid name", error.Message);
    }
}