using TRINV.Domain.Common.Exceptions;

namespace TRINV.Domain.ExternalAssetIntegration.ExternalResources.Exceptions;

public class InvalidRequestExternalResourceException : BaseDomainException
{
    public InvalidRequestExternalResourceException(string error) => Error = error;
}
