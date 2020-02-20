using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;
using Primordial.System.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace Primordial.Exceptions.Models
{
	/// <summary>
	/// Exception model.
	/// </summary>
	[DataContract(Name = "exception-model")]
	public class ExceptionModel
	{
		public ExceptionModel()
		{

		}

		public ExceptionModel(string message)
			: this(StatusCodes.Status400BadRequest, message, Severity.Error)
		{

		}

		public ExceptionModel(string message, Severity severity)
			: this(StatusCodes.Status400BadRequest, message, severity)
		{

		}

		public ExceptionModel(int code, Severity severity)
			: this(code, String.Empty, severity)
		{

		}

		public ExceptionModel(int code, string message)
			: this(code, message, Severity.Error)
		{

		}

		public ExceptionModel(int code, string message, Severity severity)
		{
			Code = code;
			Message = message;
			Severity = severity;
		}

		/// <summary>
		/// Exception code.
		/// </summary>
		[DataMember(Name = "code")]
		public int Code { get; set; }

		/// <summary>
		/// Exception message.
		/// </summary>
		[DataMember(Name = "message")]
		public string Message { get; set; }

		/// <summary>
		/// Severity.
		/// </summary>
		[DataMember(Name = "severity")]
		public Severity Severity { get; set; }

		/// <summary>
		/// Exception source.
		/// </summary>
		[DataMember(Name = "source")]
		public string Source { get; set; }

		/// <summary>
		/// List of inner exception models.
		/// </summary>
		[DataMember(Name = "exceptions")]
		public IEnumerable<ExceptionModel> InnerExceptionModels { get; set; }

		public static ExceptionModel Create(ModelStateDictionary modelStates)
		{
			if (modelStates == null)
			{
				return null;
			}

			List<ExceptionModel> exceptions = new List<ExceptionModel>();

			foreach (var key in modelStates.Keys)
			{
				exceptions.AddRange(Create(modelStates[key].Errors, key));
			}

			if (exceptions == null || exceptions.Count == 0)
			{
				return null;
			}

			if (exceptions.Count == 1)
			{
				return exceptions.FirstOrDefault();
			}
			else
			{
				ExceptionModel exception = new ExceptionModel
				{
					Code = StatusCodes.Status400BadRequest,

					Severity = Severity.Error,

					Message = "There are multiple errors. See inner exceptions for additional details.",

					InnerExceptionModels = exceptions
				};

				return exception;
			}
		}

		private static List<ExceptionModel> Create(ModelErrorCollection errors, string key)
		{
			List<ExceptionModel> exceptions = new List<ExceptionModel>();

			foreach (var error in errors)
			{
				exceptions.Add(Create(error, key));
			}

			return exceptions;
		}

		private static ExceptionModel Create(ModelError modelError, string source)
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

			try
			{
				return JsonConvert.DeserializeObject<ExceptionModel>(message);
			}
			//Message is not in expected format, so try something else.
			catch { }

			return new ExceptionModel()
			{
				Code = StatusCodes.Status400BadRequest,
				Message = message,
				Severity = Severity.Error,
				Source = source
			};
		}
	}
}
