using TRINV.Domain.Common.Exceptions;

namespace TRINV.Domain.ExternalAssetIntegration.ExternalResources.Exceptions;

public class InvalidIntegrationModelException : BaseDomainException
{
    public InvalidIntegrationModelException(string error) => Error = error;
}
