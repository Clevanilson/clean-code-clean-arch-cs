namespace AccountService.Domain;

public class Password
{
    private readonly string _Value;
    private const int _MIN_LENGTH = 8;

    public Password(string password)
    {
        if (!Validate(password)) throw new DomainError("Invalid password");
        _Value = password;
    }

    public string Valor
    {
        get { return _Value; }
    }

    private static bool Validate(string password)
    {
        if (string.IsNullOrEmpty(password)) return false;
        if (password.Length < _MIN_LENGTH) return false;
        if (!password.Any(char.IsUpper)) return false;
        if (!password.Any(char.IsLower)) return false;
        if (!password.Any(char.IsDigit)) return false;
        return true;
    }
}