using AutoMapper;

namespace TRINV.Domain.Common.Mapping;

public interface IMapFrom<TSource>
{
    void Mapping(Profile mapper) => mapper.CreateMap(typeof(TSource), GetType());
}
