using System.Text.RegularExpressions;

namespace AccountService.Domain;

public class Document
{
    private readonly string _Value;
    private const int _VALID_LENGTH = 11;

    public Document(string document)
    {
        if (!Validate(document)) throw new DomainError("Invalid document");
        _Value = document;
    }

    public string Valor
    {
        get { return _Value; }
    }

    private bool Validate(string cpf)
    {
        if (string.IsNullOrEmpty(cpf)) return false;
        cpf = Clean(cpf);
        if (cpf.Length != _VALID_LENGTH) return false;
        if (AllDigitsEqual(cpf)) return false;
        var dg1 = CalculateDigit(cpf, 10);
        var dg2 = CalculateDigit(cpf, 11);
        return ExtractDigit(cpf) == $"{dg1}{dg2}";
    }

    private static string Clean(string cpf)
    {
        return Regex.Replace(cpf, "\\D", "");
    }

    private static bool AllDigitsEqual(string cpf)
    {
        var firstDigit = cpf[0];
        return cpf.All(digit => digit == firstDigit);
    }

    private static int CalculateDigit(string cpf, int factor)
    {
        int total = 0;
        foreach (var digit in cpf)
        {
            if (factor > 1) total += int.Parse(digit.ToString()) * factor--;
        }
        int rest = total % 11;
        return (rest < 2) ? 0 : 11 - rest;
    }

    private static string ExtractDigit(string cpf)
    {
        return cpf.Substring(cpf.Length - 2, 2);
    }
}