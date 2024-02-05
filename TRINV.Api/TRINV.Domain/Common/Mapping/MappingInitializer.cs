namespace TRINV.Domain.Common.Mapping;

internal class MappingInitializer : IMappingInitializer
{
    readonly IEnumerable<IInitialMapping> initialMappingProviders;

    public MappingInitializer(IEnumerable<IInitialMapping> initialMappingProviders)
    {
        this.initialMappingProviders = initialMappingProviders;
    }

    public void InitializeMappings()
    {
        foreach (var item in this.initialMappingProviders)
        {
            item.Initialize();
        }
    }
}
