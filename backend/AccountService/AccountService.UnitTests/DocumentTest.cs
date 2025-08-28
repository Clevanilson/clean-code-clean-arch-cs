using AccountService.Domain;

public class DocumentTest
{
    [Theory]
    [InlineData("97456321558")]
    [InlineData("71428793860")]
    [InlineData("87748248800")]
    [InlineData("877.482.488-00")]
    [InlineData("877.482.48800")]
    [InlineData("877.48248800")]
    public void WithValidValue(string cpf)
    {
        var document = new Document(cpf);
        Assert.Equal(document.Valor, cpf);
    }

    [Theory]
    [InlineData("")]
    [InlineData("111")]
    [InlineData("11111111111")]
    [InlineData("abc")]
    public void WithInvalidValue(string cpf)
    {
        var error = Assert.Throws<DomainError>(() => new Document(cpf));
        Assert.Equal("Invalid document", error.Message);
    }
}