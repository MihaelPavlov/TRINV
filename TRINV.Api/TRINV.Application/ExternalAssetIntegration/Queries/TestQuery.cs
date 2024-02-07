using AutoMapper;
using MediatR;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;
using TRINV.Application.ExternalAssetIntegration.Repositories;
using TRINV.Domain.Common.Mapping;
using TRINV.Domain.ExternalAssetIntegration.Dashboard.Models;
using TRINV.Domain.ExternalAssetIntegration.Dashboard.Repositories;
using TRINV.Domain.ExternalAssetIntegration.Dashboard.Services;

namespace TRINV.Application.ExternalAssetIntegration.Queries;

public class TestQuery : IRequest<IEnumerable<AssetInfo>>
{
}

internal class TestQueryHandler : IRequestHandler<TestQuery, IEnumerable<AssetInfo>>
{
    readonly IExternalAssetsService externalAssetsService;
    readonly ITestQueryRepository testQueryRepository;
    readonly IInvestmentDomainRepository investmentDomainRepository;
    readonly IMapper mapper;
    public TestQueryHandler(IExternalAssetsService externalAssetsService,
        ITestQueryRepository testQueryRepository, IInvestmentDomainRepository investmentDomainRepository, IMapper mapper)
    {
        this.externalAssetsService = externalAssetsService;
        this.testQueryRepository = testQueryRepository;
        this.investmentDomainRepository = investmentDomainRepository;
        this.mapper = mapper;
    }

    public async Task<IEnumerable<AssetInfo>> Handle(TestQuery request, CancellationToken cancellationToken)
    {
        //var test2 = new TestSource
        //{
        //    Id = 1,
        //    FirstName = "da",
        //    LastName = "last-da",
        //};

        //var res = this.mapper.Map<TestDestination>(test2);

        //var test = await this.testQueryRepository.GetAll();
        //var tes =await  this.investmentDomainRepository.GetAllByAccount(1,cancellationToken);
        return await this.externalAssetsService.GetExternalAssetsAsync(CancellationToken.None);
    }
}

public class TestSource : IMapFrom<TestDestination>
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public virtual void Mapping(Profile mapper)
      => mapper.CreateMap<TestSource, TestDestination>()
        .ForMember(dest=>dest.lastName , opt=>opt.MapFrom(src=> "Custom LastName"));
}


public class TestDestination
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string lastName { get; set; }

}
