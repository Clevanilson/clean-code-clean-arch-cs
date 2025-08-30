using AccountSerivice.Domain.Interfaces;

namespace AccountService.Domain;

public class DomainError : Exception, IDomainError
{
    public int Code => 400;
    public string Action => "Please check the request data and try again.";
    public DomainError(string message) : base(message) { }
}