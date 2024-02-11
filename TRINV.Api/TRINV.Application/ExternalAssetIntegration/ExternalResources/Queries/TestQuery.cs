using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TRINV.Application.ExternalAssetIntegration.ExternalResources.Builders.Interfaces;
using TRINV.Application.ExternalAssetIntegration.ExternalResources.Models;

namespace TRINV.Application.ExternalAssetIntegration.ExternalResources.Queries;

public class TestQuery : IRequest<IEnumerable<ExternalIntegrationResourceResultModel>>
{
}
internal class TestQueryHandler : IRequestHandler<TestQuery, IEnumerable<ExternalIntegrationResourceResultModel>>
{
    IEnumerable<IExternalIntegrationResourceBuilder> builders;
    public TestQueryHandler(IEnumerable<IExternalIntegrationResourceBuilder> builders)
    {
        this.builders = builders;
    }

    public async Task<IEnumerable<ExternalIntegrationResourceResultModel>> Handle(TestQuery request, CancellationToken cancellationToken)
    {
        var res = await this.builders.First().Build(cancellationToken);
        var result = new List<ExternalIntegrationResourceResultModel>();
        foreach (var item in this.builders)
        {
            var res2 = await item.Build(cancellationToken);
            if (res2 != null && res2.RelatedObject != null)
                result.AddRange(res2.RelatedObject);
        }
        return result;
    }
}
