using AutoMapper;

namespace TRINV.Domain.Common.Mapping;

public interface IMapFrom<T>
{
    void Mapping(Profile mapper) => mapper.CreateMap(typeof(T), GetType());
}
