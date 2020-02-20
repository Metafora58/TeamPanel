using System;
using System.Collections.Generic;
using System.Text;

namespace System
{
    public static class StringExtensions
    {
		public static bool IsNullOrWhiteSpace(this string s)
		{
			return String.IsNullOrWhiteSpace(s);
		}

		public static bool IsNotNullOrWhiteSpace(this string s)
		{
			return !String.IsNullOrWhiteSpace(s);
		}

		public static bool IsNullOrEmpty(this string s)
		{
			return String.IsNullOrEmpty(s);
		}

		public static bool IsNotNullOrEmpty(this string s)
		{
			return !String.IsNullOrEmpty(s);
		}

		public static string IfNullOrEmpty(this string s, params string[] fallbacks)
		{
			if (s.IsNullOrEmpty())
			{
				foreach (string fallback in fallbacks)
				{
					if (!fallback.IsNullOrEmpty())
					{
						return fallback;
					}
				}
			}

			return s;
		}
	}
}
