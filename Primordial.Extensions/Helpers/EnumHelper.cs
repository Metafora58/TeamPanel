using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Primordial.System.Helpers
{
    public static class EnumHelper
    {
		public static string GetDisplayName(object value)
		{
			if (value == null)
			{
				return null;
			}

			DisplayAttribute displayAttribute = DisplayAttributeHelper.GetDisplayAttribute(value.GetType(), value.ToString());

			if (displayAttribute == null)
			{
				return value.ToString();
			}

			string displayName = displayAttribute.GetName();

			if (displayName.IsNullOrEmpty())
			{
				displayName = displayAttribute.GetDescription();
			}

			return displayName;
		}

		public static E GetValueByDataMemberName<E>(string dataMamberName)
		{
			if (string.IsNullOrEmpty(dataMamberName))
			{
				return default;
			}

			foreach (var value in Enum.GetValues(typeof(E)))
			{
				DataMemberAttribute dataMemberAttribute = TypeHelper.GetAttribute<DataMemberAttribute>(typeof(E), value.ToString());

				if (dataMemberAttribute != null)
				{
					if (dataMemberAttribute.Name == dataMamberName)
					{
						return (E)value;
					}
				}
			}

			return default;
		}

		public static E GetEnum<E>(int enumId)
		{
			return (E)(Enum.ToObject(typeof(E), enumId));
		}

		public static E GetEnum<E>(string enumName)
		{
			return (E)(Enum.Parse(typeof(E), enumName));
		}

		public static bool IsEnum(this Type type)
		{
			if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>))
			{
				type = Nullable.GetUnderlyingType(type);
			}

			return type.IsEnum;
		}
	}
}
