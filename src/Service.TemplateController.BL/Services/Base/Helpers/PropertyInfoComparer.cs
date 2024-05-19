using System.Reflection;

namespace Service.TemplateController.BL.Services.Base.Helpers;

internal class PropertyInfoComparer : IEqualityComparer<PropertyInfo>
{
    public bool Equals(PropertyInfo? x, PropertyInfo? y)
    {
        return x?.Name == y?.Name;
    }

    public int GetHashCode(PropertyInfo obj)
    {
        return obj.Name.GetHashCode();
    }
}