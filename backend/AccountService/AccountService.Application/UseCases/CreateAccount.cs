using AccountSerivice.Domain.DTOs;
using AccountService.Application.Repositories;
using AccountService.Domain;

namespace AccountSerivice.Application.UseCases;

public class CreateAccount
{
    private readonly IAccountRepoistory _repository;

    public CreateAccount(IAccountRepoistory repository)
    {
        _repository = repository;
    }

    public async Task<Guid> Execute(AccountInputDTO input)
    {
        var existingAccount = await this._repository.GetByDocumentAsync(input.Document);
        if (existingAccount != null) throw new DomainError("Account already exists for this document");
        var account = new Account(input.Name, input.Document, input.Password);
        await this._repository.SaveAsync(account);
        return account.Id;
    }
}