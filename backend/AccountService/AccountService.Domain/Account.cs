namespace AccountService.Domain;

public class Account
{
    readonly Guid _Id;
    private Name _Name;
    private Document _Document;
    private Password? _Password;

    public Account(string name, string document, string password)
    {
        _Name = new Name(name);
        _Document = new Document(document);
        _Password = new Password(password);
        _Id = Guid.NewGuid();
    }

    public Account(Guid id, string name, string document)
    {
        _Id = id;
        _Name = new Name(name);
        _Document = new Document(document);
    }

    public Guid Id
    {
        get { return _Id; }
    }

    public string Name
    {
        get { return _Name.Valor; }
    }

    public string Document
    {
        get { return _Document.Valor; }
    }

    public string Password
    {
        get { return _Password?.Valor ?? "" ; }
    }

}