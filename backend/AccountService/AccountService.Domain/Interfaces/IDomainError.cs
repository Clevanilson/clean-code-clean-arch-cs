namespace AccountSerivice.Domain.Interfaces; 

public interface IDomainError
{
    int Code { get; }
    string Action { get; }
    string Message { get; }
}