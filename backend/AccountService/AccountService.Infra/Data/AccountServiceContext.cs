using Microsoft.EntityFrameworkCore;
using AccountService.Infra.Models;

namespace AccountService.Infra.Data;


public class AccountServiceContext : DbContext
{
    public AccountServiceContext(DbContextOptions<AccountServiceContext> options) : base(options)
    {
    }

    public DbSet<AccountModel> Accounts { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<AccountModel>().HasIndex(model => model.Document).IsUnique();
    }

}