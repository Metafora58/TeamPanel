using Microsoft.AspNetCore.Mvc.Filters;
using System;
using Serilog;
using Microsoft.AspNetCore.Http;
using System.Net;
using Primordial.Exceptions.Exceptions;
using Primordial.Exceptions.Models;
using Newtonsoft.Json;

namespace Primordial.Exceptions.ExceptionFilters
{
	public class ApiExceptionFilter : IExceptionFilter
	{
		readonly ILogger Logger;

		public ApiExceptionFilter(ILogger logger = null)
		{
			Logger = logger;
		}

		public void OnException(ExceptionContext context)
		{
			if (Logger != null)
			{
				Logger.Error(context.Exception, "ApiExceptionFilter");
			}

			HttpResponse response = context.HttpContext.Response;

			response.StatusCode = (int)HttpStatusCode.BadRequest;

			if (context.Exception is CodeException == false &&
				context.Exception is ApiException == false)
			{
				response.StatusCode = (int)HttpStatusCode.InternalServerError;
			}

			ExceptionModel error = context.Exception.GetExceptionModel();

			response.ContentType = "application/json";

			var errorResponse = JsonConvert.SerializeObject(error);

			context.ExceptionHandled = true;

			response.WriteAsync(errorResponse);
		}
	}
}
