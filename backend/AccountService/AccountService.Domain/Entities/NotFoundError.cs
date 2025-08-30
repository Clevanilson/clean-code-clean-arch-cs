using AccountSerivice.Domain.Interfaces;

namespace AccountService.Domain.Entities;

public class NotFoundError : Exception, IDomainError
{
    public int Code => 404;
    public string Action => "Please verify the provided identifier and try again.";
    public NotFoundError(string message) : base(message) { }
}