using AccountService.Infra.Data;
using AccountService.Infra.Models;
using AccountService.Domain;
using AccountService.Application.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AccountService.Infra.Repositories;

public class AccountRepository : IAccountRepoistory

{
    private readonly AccountServiceContext _context;

    public AccountRepository(AccountServiceContext context)
    {
        _context = context;
    }

    public async Task SaveAsync(Account account)
    {
        var accountModel = new AccountModel
        {
            Id = account.Id,
            Name = account.Name,
            Document = account.Document,
            Password = account.Password
        };
        _context.Accounts.Add(accountModel);
        await _context.SaveChangesAsync();
    }

    public async Task<Account?> GetByIdAsync(Guid id)
    {
        var accountModel = await _context.Accounts.FindAsync(id);
        if (accountModel == null) return null;
        return new Account(accountModel.Id, accountModel.Name, accountModel.Document);
    }

    public async Task<Account?> GetByDocumentAsync(string document)
    {
        var account = await _context.Accounts
            .Where(model => model.Document == document)
            .Select(model => new Account(model.Id, model.Name, model.Document))
            .FirstOrDefaultAsync();
        return account;
    }
}