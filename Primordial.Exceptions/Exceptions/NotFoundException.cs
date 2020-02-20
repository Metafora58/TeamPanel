using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Primordial.Exceptions.Exceptions
{
	/// <summary>
	/// Identifies exception which is thrown when requiring resource is not found.
	/// </summary>
	public class NotFoundException : CodeException
	{
		public NotFoundException()
			: base("Required resource not found.", StatusCodes.Status404NotFound)
		{

		}

		public NotFoundException(string message)
			: base(message, StatusCodes.Status403Forbidden)
		{

		}
	}
}
