using Microsoft.AspNetCore.Http;
using Primordial.Exceptions.Exceptions;
using Primordial.Exceptions.Models;
using Primordial.System.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace System
{
	public static class ExceptionExtensions
	{
		public static ExceptionModel GetExceptionModel(this Exception exception)
		{
			ApiException apiException = exception as ApiException;

			if (apiException != null)
			{
				if (apiException.StatusCode == StatusCodes.Status401Unauthorized)
				{
					return new ExceptionModel()
					{
						Code = apiException.StatusCode,
						Message = "Unauthorized",
						Severity = Severity.Error,
						Source = apiException.Source
					};
				}

				List<ExceptionModel> innerExceptions = new List<ExceptionModel>();

				foreach (BusinessException ex in apiException.BusinessExceptions)
				{
					innerExceptions.Add(new ExceptionModel()
					{
						Code = ex.Code,
						Message = ex.Message,
						Severity = ex.Severity,
						Source = ex.Source
					});
				}

				ExceptionModel exceptionModel = new ExceptionModel()
				{
					Code = apiException.StatusCode,
					Message = apiException.Message,
					Severity = Severity.Error,
					Source = apiException.Source
				};

				if (innerExceptions != null && innerExceptions.Count > 0)
				{
					exceptionModel.InnerExceptionModels = innerExceptions;
				}

				return exceptionModel;
			}

			BusinessException businessException = exception as BusinessException;

			if (businessException != null)
			{
				return new ExceptionModel()
				{
					Code = businessException.Code,
					Message = businessException.Message,
					Severity = businessException.Severity,
					Source = businessException.Source
				};
			}

			CodeException codeException = exception as CodeException;

			if (codeException != null)
			{
				return new ExceptionModel()
				{
					Code = codeException.Code,
					Message = codeException.Message,
					Severity = Severity.Error,
					Source = codeException.Source
				};
			}

			return new ExceptionModel()
			{
				Code = StatusCodes.Status500InternalServerError,
				Message = "Internal server error occurred.",
				Severity = Severity.Error,
				Source = exception?.Source
			};
		}
	}
}
