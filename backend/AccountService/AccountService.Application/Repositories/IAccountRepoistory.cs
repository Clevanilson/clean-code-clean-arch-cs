using AccountService.Domain;

namespace AccountService.Application.Repositories;

public interface IAccountRepoistory
{
    Task SaveAsync(Account account);
    Task<Account?> GetByIdAsync(Guid id);
    Task<Account?> GetByDocumentAsync(string document);
}