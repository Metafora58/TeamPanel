using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Primordial.System.Enums;
using System;

namespace Primordial.Exceptions.Validation
{
	public class ValidationMessage
    {
		public int Code { get; set; }

		public string Message { get; set; }

		public Severity Severity { get; set; }

		public static ValidationMessage Create(ModelError modelError)
		{
			if (modelError == null)
			{
				return null;
			}

			string message = modelError.ErrorMessage ?? (modelError.Exception?.Message);

			if (message.IsNullOrEmpty())
			{
				return null;
			}

			//message formats: 
			//Code|Severity|Message

			string[] parts = message.Split('|');

			int code = StatusCodes.Status400BadRequest;

			Severity severity = Severity.Error;

			if (parts.Length == 3)
			{
				int.TryParse(parts[0], out code);
				Enum.TryParse<Severity>(parts[1], out severity);
				message = parts[2];
			}
			else if (parts.Length == 2)
			{
				string firstPart = parts[0];

				if (int.TryParse(firstPart, out code) == false)
				{
					Enum.TryParse<Severity>(firstPart, out severity);
				}

				message = parts[1];
			}

			return new ValidationMessage()
			{
				Code = code,
				Severity = severity,
				Message = message
			};
		}
	}	
}
