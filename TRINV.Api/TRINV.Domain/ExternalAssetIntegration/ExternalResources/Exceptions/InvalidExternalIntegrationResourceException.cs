using TRINV.Domain.Common.Exceptions;

namespace TRINV.Domain.ExternalAssetIntegration.ExternalResources.Exceptions;

public class InvalidExternalIntegrationResourceException : BaseDomainException
{
    public InvalidExternalIntegrationResourceException(string error) => Error = error;
}
