using TRINV.Domain.Common;
using TRINV.Domain.UserManagement.Accounts.Enums;

namespace TRINV.Domain.UserManagement.Accounts.Models;

public class Account : Entity<int>, IAggregateRoot
{
    readonly List<AccountExternalResource> accountExternalResources;

    internal Account(int userId, AccountType accountType)
    {
        this.UserId = userId;
        this.AccountType = accountType;

        this.accountExternalResources = new List<AccountExternalResource>();
    }

    public int UserId { get; private set; }
    public AccountType AccountType { get; private set; }
    public IReadOnlyCollection<AccountExternalResource> AccountExternalResources => this.accountExternalResources.AsReadOnly();

    public void AddAccountExternalResource(AccountExternalResource accountExternalResource)
    {
        this.accountExternalResources.Add(accountExternalResource);
    }
}
