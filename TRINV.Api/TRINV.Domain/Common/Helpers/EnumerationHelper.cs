using System.Reflection;
using TRINV.Domain.ExternalAssetIntegration.ExternalResources.Enums;

namespace TRINV.Domain.Common.Helpers;

public abstract class EnumerationHelper : IComparable
{
    public int Id { get; private set; }

    public string Name { get; private set; }

    public ExternalResourceCategory Category { get; private set; }

    protected EnumerationHelper(int id, string name, ExternalResourceCategory category) => (this.Id, this.Name, this.Category) = (id, name, category);

    public override string ToString() => Name;

    public static IEnumerable<T> GetAll<T>() where T : EnumerationHelper =>
        typeof(T).GetFields(BindingFlags.Public |
                            BindingFlags.Static |
                            BindingFlags.DeclaredOnly)
                 .Select(f => f.GetValue(null))
                 .Cast<T>();

    public override bool Equals(object? obj)
    {
        if (obj is not EnumerationHelper otherValue)
        {
            return false;
        }

        var typeMatches = GetType().Equals(obj.GetType());
        var valueMatches = Id.Equals(otherValue.Id);

        return typeMatches && valueMatches;
    }

    public int CompareTo(object? other)
    {
        if (other is null)
        {
            return 1;
        }
        else if (other is not null)
        {
            return Id.CompareTo(((EnumerationHelper)other).Id);
        }

        throw new ArgumentException("Object is not a Enumeration Helper");
    }


    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }
}
