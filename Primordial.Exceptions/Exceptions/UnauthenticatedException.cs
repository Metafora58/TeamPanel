using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace Primordial.Exceptions.Exceptions
{
	/// <summary>
	/// Identifies that user is not authenticated.
	/// </summary>
	public class UnauthenticatedException : CodeException
	{
		public UnauthenticatedException()
			: base(String.Empty, StatusCodes.Status403Forbidden)
		{

		}

		public UnauthenticatedException(string message)
			: base(message, StatusCodes.Status403Forbidden)
		{

		}

		public UnauthenticatedException(ClaimsIdentity claimsIdentity)
			: base(GetMessage(claimsIdentity), StatusCodes.Status403Forbidden)
		{
		}

		private static string GetMessage(ClaimsIdentity claimsIdentity)
		{
			string identityName = String.Empty;

			if (claimsIdentity != null)
			{
				identityName = claimsIdentity.Name;
			}

			return $"Identity of user {identityName} doesn't confirmed.";
		}
	}
}
