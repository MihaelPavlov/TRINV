using AutoMapper;
using System.Reflection;

namespace TRINV.Domain.Common.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
            => ApplyMappingsFromAssembly(AppDomain.CurrentDomain.GetAssemblies());

        private void ApplyMappingsFromAssembly(Assembly[] assemblies)
        {
            foreach (var assembly in assemblies)
            {
                var types = new List<Type>();
                try
                {
                    types = assembly
                       .GetExportedTypes()
                       .Where(t => t
                           .GetInterfaces()
                           .Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IMapFrom<>)))
                       .ToList();
                }
                catch (Exception)
                {
                }

                foreach (var type in types)
                {
                    var instance = Activator.CreateInstance(type);

                    const string mappingMethodName = "Mapping";

                    var methodInfo = type.GetMethod(mappingMethodName)
                                     ?? type.GetInterface("IMapFrom`1")?.GetMethod(mappingMethodName);

                    methodInfo?.Invoke(instance, new object[] { this });
                }
            }
        }
    }
}
