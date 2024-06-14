using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Lubee.Extensions;

public static class EnumExtensions
{
  public static string GetEnumAttributeValue<TAttribute>(this Enum enumValue, Func<TAttribute, string?> valueSelector) where TAttribute : Attribute
  {
    var enumType = enumValue.GetType();
    var member = enumType.GetMember(enumValue.ToString()).FirstOrDefault();

    if (member is not null)
    {
      var attribute = member.GetCustomAttribute<TAttribute>();
      if (attribute is not null)
      {
        return valueSelector(attribute) ?? enumValue.ToString();
      }
    }

    return enumValue.ToString();
  }

  public static string GetDisplayName(this Enum enumValue)
  {
    return enumValue.GetEnumAttributeValue<DisplayAttribute>(attr => attr.Name);
  }

  public static string GetDescription(this Enum enumValue)
  {
    return enumValue.GetEnumAttributeValue<DisplayAttribute>(attr => attr.Description);
  }
}