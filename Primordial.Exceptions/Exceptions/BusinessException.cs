using Microsoft.AspNetCore.Http;
using Primordial.System.Enums;

namespace Primordial.Exceptions.Exceptions
{
	/// <summary>
	/// Business exception identifies business/validation problem occured during processing.
	/// </summary>
	public class BusinessException : CodeException
	{
		public BusinessException()
		: base()
		{

		}

		public BusinessException(string message)
			: base(message, StatusCodes.Status400BadRequest)
		{

		}

		public BusinessException(string message, int code)
			: base(message, code)
		{

		}

		public BusinessException(string message, int code, Severity severity)
			: base(message, code)
		{
			Severity = severity;
		}

		public Severity Severity { get; set; }
	}
}
