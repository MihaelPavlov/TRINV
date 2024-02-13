using TRINV.Domain.Common;
using TRINV.Domain.UserManagement.Accounts.Exceptions;

namespace TRINV.Domain.UserManagement.Accounts.Models;

public class AccountExternalResource : IAggregateRoot
{
    internal AccountExternalResource(int accountId, int externalIntegrationResourceId)
    {
        this.Validate(accountId, externalIntegrationResourceId);

        this.AccountId = accountId;
        this.ExternalIntegrationResourceId = externalIntegrationResourceId;
    }

    public int AccountId { get; private set; }
    public int ExternalIntegrationResourceId { get; private set; }

    public AccountExternalResource UpdateAccountId(int accountId)
    {
        this.AccountId = accountId;
        return this;
    }

    public AccountExternalResource UpdateExternalIntegrationResourceId(int externalIntegrationResourceId)
    {
        this.ExternalIntegrationResourceId = externalIntegrationResourceId;
        return this;
    }

    public void Validate(int accountId, int externalIntegrationResourceId)
    {
        if (accountId == 0 || externalIntegrationResourceId == 0)
            throw new InvalidAccountExternalResourceException("Account External Resource is invalid");
    }
}
