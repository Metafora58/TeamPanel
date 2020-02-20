using Primordial.System.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Primordial.Exceptions.Validation
{
	public static class ValidationResultsExtensions
	{
		public static void AddValidationCodeResult(this List<ValidationResult> validationResults, ValidationCodeResult validationResult)
		{
			if (validationResults == null)
			{
				throw new ArgumentNullException(nameof(validationResults));
			}

			if (validationResult == null)
			{
				throw new ArgumentNullException(nameof(validationResult));
			}

			validationResults.Add(validationResult);
		}

		public static void AddValidationCodeResult(this List<ValidationResult> validationResults, string message)
		{
			if (validationResults == null)
			{
				throw new ArgumentNullException(nameof(validationResults));
			}

			AddValidationCodeResult(validationResults, new ValidationCodeResult(message));
		}

		public static void AddValidationCodeResult(this List<ValidationResult> validationResults, string message, int code)
		{
			if (validationResults == null)
			{
				throw new ArgumentNullException(nameof(validationResults));
			}

			AddValidationCodeResult(validationResults, new ValidationCodeResult(message, code));
		}

		public static void AddValidationCodeResult(this List<ValidationResult> validationResults, string message, Severity severity)
		{
			if (validationResults == null)
			{
				throw new ArgumentNullException(nameof(validationResults));
			}

			AddValidationCodeResult(validationResults, new ValidationCodeResult(message, severity));
		}

		public static void AddValidationCodeResult(this List<ValidationResult> validationResults, string message, int code, Severity severity)
		{
			if (validationResults == null)
			{
				throw new ArgumentNullException(nameof(validationResults));
			}

			AddValidationCodeResult(validationResults, new ValidationCodeResult(message, code, severity));
		}
	}
}
