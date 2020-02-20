using System;
using System.Collections.Generic;
using System.Text;

namespace Primordial.System.Helpers
{
    public static class TypeHelper
    {
		public static A GetAttribute<A>(Type type, string memberName)
			where A : Attribute
		{
			if (String.IsNullOrEmpty(memberName))
			{
				throw new ArgumentNullException(nameof(memberName));
			}

			if (type == null)
			{
				throw new ArgumentNullException(nameof(type));
			}

			Type underlyingType = GetUnderlyingType(type);

			var memberInfos = underlyingType.GetMember(memberName);

			A attribute = null;

			if (memberInfos != null && memberInfos.Length > 0)
			{
				var attributes = memberInfos[0].GetCustomAttributes(typeof(A), false);

				if (attributes != null && attributes.Length > 0)
				{
					attribute = ((A)attributes[0]);
				}
			}

			return attribute;
		}

		public static bool IsNullable(Type type)
		{
			return Nullable.GetUnderlyingType(type) != null;
		}

		public static Type GetUnderlyingType(Type type)
		{
			if (type == null)
			{
				return null;
			}

			Type underlyingType = Nullable.GetUnderlyingType(type);

			if (underlyingType == null)
			{
				return type;
			}

			return underlyingType;
		}
	}
}
