using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace Primordial.Exceptions.Exceptions
{
	/// <summary>
	/// Identifies excetion thrown when user is authenticated but accessing resource is forbidden.
	/// </summary>
	public class ForbiddenException : CodeException
	{
		public ForbiddenException()
			: base(String.Empty, StatusCodes.Status403Forbidden)
		{

		}

		public ForbiddenException(string message)
			: base(message, StatusCodes.Status403Forbidden)
		{

		}

		public ForbiddenException(ClaimsIdentity claimsIdentity, string roles)
			: base(GetMessage(claimsIdentity, roles), StatusCodes.Status403Forbidden)
		{

		}

		private static string GetMessage(ClaimsIdentity claimsIdentity, string roles)
		{
			string message = String.Empty;

			string userName = String.Empty;

			if (claimsIdentity != null)
			{
				userName = claimsIdentity.Name;
			}

			string userMessage = $"User {userName} doesn't have access right for required resource.";

			string rolesMessage = String.Empty;

			if (String.IsNullOrEmpty(roles))
			{
				var rolesArray = roles.Split(',');

				int roleCount = rolesArray.Length;

				if (roleCount > 0)
				{
					if (roleCount == 1)
					{
						rolesMessage = $"\nUser must be member of a group {roles}.";
					}
					else
					{
						rolesMessage = $"\nUser must be member in some of following groups: {roles}.";
					}
				}
			}

			message = $"{userMessage}{rolesMessage}";

			return message;
		}
	}
}
