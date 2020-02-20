using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Primordial.System.Helpers
{
    public static class DisplayAttributeHelper
    {
		public static DisplayAttribute GetDisplayAttribute(Type type, string memberName)
		{
			if (String.IsNullOrEmpty(memberName))
			{
				throw new ArgumentNullException(nameof(memberName));
			}

			if (type == null)
			{
				throw new ArgumentNullException(nameof(type));
			}

			DisplayAttribute displayAttribute = TypeHelper.GetAttribute<DisplayAttribute>(type, memberName);

			return displayAttribute;
		}
	}
}
