using System.Collections.Generic;
using TRINV.Application.ExternalAssetIntegration.ExternalResources.Builders.Interfaces;
using TRINV.Application.ExternalAssetIntegration.ExternalResources.Models;
using TRINV.Application.ExternalAssetIntegration.ExternalResources.Services.ExtenalIntegrationResouces.Interfaces;
using TRINV.Domain.ExternalAssetIntegration.ExternalResources.Enums;
using TRINV.Shared.Business.Utilities;

namespace TRINV.Application.ExternalAssetIntegration.ExternalResources.Services.ExtenalIntegrationResouces;

internal class ExternalIntegrationResourceServicve : IExternalIntegrationResourceService
{
    IEnumerable<IExternalIntegrationResourceBuilder> builders;

    public ExternalIntegrationResourceServicve(IEnumerable<IExternalIntegrationResourceBuilder> builders)
    {
        this.builders = builders;
    }

    // Maybe remove this. Think of a case where we would need all
    public async Task<OperationResult<IEnumerable<ExternalIntegrationResourceResultModel>>> ExecuteAll(CancellationToken cancellationToken)
    {
        var collection = new List<ExternalIntegrationResourceResultModel>();
        foreach (var resource in this.builders)
        {
            var result = await resource.Build(cancellationToken);

            if (!result.Success || result.RelatedObject is null)
            {
                //TODO: Operation Result extension method for getting the exception from other operationResult; operationResult.Get

                /*
                 
                   /// <summary>
        /// Appends error messages from one <typeparamref name="TOriginal"/> to another <typeparamref name="TOther"/>.
        /// </summary>
        /// <param name="originalOperationResult">The <see cref="OperationResult"/> to append to.</param>
        /// <param name="otherOperationResult">The <see cref="OperationResult"/> to append from.</param>
        /// <typeparam name="TOriginal">A type that inherits from <see cref="OperationResult"/>.</typeparam>
        /// <typeparam name="TOther">A type that inherits from <see cref="OperationResult"/>.</typeparam>
        /// <returns>The original <see cref="OperationResult"/> with the appended messages from the other <typeparamref name="TOther"/>.</returns>
        public static TOriginal AppendErrorMessages<TOriginal, TOther>(this TOriginal originalOperationResult, TOther otherOperationResult)
            where TOriginal : OperationResult
            where TOther : OperationResult
        {
            if (originalOperationResult is null)
                throw new ArgumentNullException(nameof(originalOperationResult));

            if (otherOperationResult is null)
                return originalOperationResult;

            // Append the error message without logging (presuming that there is already a log message).
            foreach (var error in otherOperationResult.Errors)
                originalOperationResult.AppendError(error);

            return originalOperationResult;
        }
                 */
            }
            collection.AddRange(result.RelatedObject);
        }

        return new OperationResult<IEnumerable<ExternalIntegrationResourceResultModel>>(collection);
    }

    // Execute based on account
    public async Task<OperationResult<IEnumerable<ExternalIntegrationResourceResultModel>>> ExecuteAllByCategory(ExternalResourceCategory category, CancellationToken cancellationToken)
    {
        var collection = new List<ExternalIntegrationResourceResultModel>();
        foreach (var resource in this.builders.Where(x => x.Category == category))
        {
            var result = await resource.Build(cancellationToken);

          
            collection.AddRange(result.RelatedObject);
        }

        return new OperationResult<IEnumerable<ExternalIntegrationResourceResultModel>>(collection);
    }

    // Maybe we would use this to execute it when the user logged in and use all the cached information about resources, in this case we will increase the user loading. Intead of user waithing for the resource to load the first time.se6x3svi zc
    public async Task<OperationResult<IEnumerable<ExternalIntegrationResourceResultModel>>> ExecuteAllByUserId(int userId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

}
