using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Primordial.Exceptions.Exceptions
{
	/// <summary>
	/// Identifies base exception class decorated with exception code.
	/// </summary>
	public class CodeException : Exception
	{
		public CodeException() : base()
		{

		}

		public CodeException(string message)
			: base(message)
		{

		}

		public CodeException(string message, int code)
			: base(message)
		{
			Code = code;
		}

		public int Code { get; } = StatusCodes.Status500InternalServerError;
	}
}
