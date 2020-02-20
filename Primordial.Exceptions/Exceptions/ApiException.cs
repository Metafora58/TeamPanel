using Newtonsoft.Json;
using Primordial.Exceptions.Models;
using System;
using System.Collections.Generic;

namespace Primordial.Exceptions.Exceptions
{
	public partial class ApiException : Exception
	{
		public int StatusCode { get; private set; }

		public string Response { get; private set; }

		public Dictionary<string, IEnumerable<string>> Headers { get; private set; }

		public IEnumerable<BusinessException> BusinessExceptions { get; set; }

		public ApiException(string message, int statusCode)
			: base(message)
		{
			StatusCode = statusCode;
		}

		public ApiException(string message, int statusCode, string response, Dictionary<string, IEnumerable<string>> headers, Exception innerException)
			: base(message, innerException)
		{
			StatusCode = statusCode;
			Response = response;
			Headers = headers;
			BusinessExceptions = GetBusinessExceptions(Response);
		}

		private IEnumerable<BusinessException> GetBusinessExceptions(string response)
		{
			List<BusinessException> businessExceptions = new List<BusinessException>();

			if (!response.IsNullOrEmpty())
			{
				var exceptionModel = JsonConvert.DeserializeObject<ExceptionModel>(response);

				if (exceptionModel.InnerExceptionModels != null)
				{
					foreach (ExceptionModel exception in exceptionModel.InnerExceptionModels)
					{
						if (exception != null)
						{
							businessExceptions.Add(new BusinessException(exception.Message, exception.Code, exception.Severity));
						}
					}
				}
				else
				{
					businessExceptions.Add(new BusinessException(exceptionModel.Message, exceptionModel.Code, exceptionModel.Severity));
				}
			}

			return businessExceptions;
		}

		public override string ToString()
		{
			return string.Format("HTTP Response: \n\n{0}\n\n{1}", Response, base.ToString());
		}
	}

	public partial class ApiException<TResult> : ApiException
	{
		public TResult Result { get; private set; }

		public ApiException(string message, int statusCode, string response, Dictionary<string, IEnumerable<string>> headers, TResult result, Exception innerException)
			: base(message, statusCode, response, headers, innerException)
		{
			Result = result;
		}
	}
}
