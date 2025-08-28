namespace AccountService.Domain;

public class Name
{
    private readonly string _Value;
    private const int _MIN_LENGTH = 5;

    public Name(string name)
    {
        if (!Validate(name)) throw new DomainError("Invalid name");
        _Value = name;
    }

    public string Valor
    {
        get { return _Value; }
    }

    private bool Validate(string name)
    {
        if (string.IsNullOrEmpty(name)) return false;
        if (name.Length < _MIN_LENGTH) return false;
        return true;
    }
}