using TRINV.Domain.Common.Exceptions;

namespace TRINV.Domain.UserManagement.Accounts.Exceptions;

public class InvalidAccountExternalResourceException : BaseDomainException
{
    public InvalidAccountExternalResourceException(string error) => Error = error;
}
