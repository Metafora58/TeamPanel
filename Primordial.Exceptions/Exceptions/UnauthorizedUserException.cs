using Microsoft.AspNetCore.Http;
using System;
using System.Security.Claims;

namespace Primordial.Exceptions.Exceptions
{
	/// <summary>
	/// Identifies that user is not authorized.
	/// </summary>
	public class UnauthorizedException : CodeException
	{
		public UnauthorizedException()
			: base(String.Empty, StatusCodes.Status401Unauthorized)
		{

		}

		public UnauthorizedException(string message)
			: base(message, StatusCodes.Status401Unauthorized)
		{

		}
		public UnauthorizedException(ClaimsPrincipal claimsPrincipal)
			: base(GetMessage(claimsPrincipal), StatusCodes.Status401Unauthorized)
		{

		}

		private static string GetMessage(ClaimsPrincipal claimsPrincipal)
		{
			return $"User identity not provided";
		}
	}
}
