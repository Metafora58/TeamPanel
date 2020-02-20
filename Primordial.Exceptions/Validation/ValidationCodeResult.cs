using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Primordial.Exceptions.Models;
using Primordial.System.Enums;
using System.ComponentModel.DataAnnotations;

namespace Primordial.Exceptions.Validation
{
	public class ValidationCodeResult : ValidationResult
	{
		public ValidationCodeResult(string message)
			: base(GetErrorMessage(message, StatusCodes.Status400BadRequest, Severity.Error, null))
		{
			Code = StatusCodes.Status400BadRequest;
			Severity = Severity.Error;
		}

		public ValidationCodeResult(string message, int code)
			: base(GetErrorMessage(message, code, Severity.Error, null))
		{
			Code = code;
			Severity = Severity.Error;
		}

		public ValidationCodeResult(string message, Severity severity)
			: base((GetErrorMessage(message, StatusCodes.Status400BadRequest, severity, null)))
		{
			Code = StatusCodes.Status400BadRequest;
			Severity = severity;
		}

		public ValidationCodeResult(string message, int code, Severity severity)
			: base(GetErrorMessage(message, code, severity, null))
		{
			Code = code;
			Severity = severity;
		}

		public ValidationCodeResult(string message, int code, Severity severity, string source)
			: base(GetErrorMessage(message, code, severity, source))
		{
			Code = code;
			Severity = severity;
		}

		public int Code { get; set; }

		public Severity Severity { get; set; }

		private static string GetErrorMessage(string message, int code, Severity severity, string source)
		{
			ExceptionModel exception = new ExceptionModel()
			{
				Message = message,
				Code = code,
				Severity = severity,
				Source = source
			};

			return JsonConvert.SerializeObject(exception);
		}
	}
}
