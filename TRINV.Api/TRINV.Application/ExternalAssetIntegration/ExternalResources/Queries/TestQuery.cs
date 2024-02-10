using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TRINV.Application.ExternalAssetIntegration.ExternalResources.Builders.Interfaces;

namespace TRINV.Application.ExternalAssetIntegration.ExternalResources.Queries;

public class TestQuery : IRequest<IEnumerable<object>>
{
}
internal class TestQueryHandler : IRequestHandler<TestQuery, IEnumerable<object>>
{
    IEnumerable<IExternalIntegrationResourceBuilder> builders;
    public TestQueryHandler(IEnumerable<IExternalIntegrationResourceBuilder> builders)
    {
        this.builders = builders;
    }

    public async Task<IEnumerable<object>> Handle(TestQuery request, CancellationToken cancellationToken)
    {
        var res = await this.builders.First().Build();

        foreach (var item in this.builders)
        {
            var tst = await item.Build();

        }
        return res.RelatedObject;
    }
}
