using AccountSerivice.Domain.DTOs;
using AccountService.Application.Repositories;
using AccountService.Domain.Entities;

namespace AccountSerivice.Application.UseCases;

public class GetAccount
{
    private readonly IAccountRepoistory _accountRepository;

    public GetAccount(IAccountRepoistory accountRepository)
    {
        _accountRepository = accountRepository;
    }

    public async Task<AccountOutputDTO> Execute(Guid id)
    {
        var account = await _accountRepository.GetByIdAsync(id);

        if (account is null)
        {
            throw new NotFoundError("Account not found");
        }

        return new AccountOutputDTO
        {
            Id = account.Id,
            Name = account.Name,
            Document = account.Document,
        };
    }
}