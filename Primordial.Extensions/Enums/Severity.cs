using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Primordial.System.Enums
{
	[Serializable]
	[JsonConverter(typeof(StringEnumConverter))]
	public enum Severity
	{
		[EnumMember(Value = "info")]
		[Display(Name = "Info")]
		Info = 0,

		[EnumMember(Value = "warning")]
		[Display(Name = "Warning")]
		Warning = 1,

		[EnumMember(Value = "error")]
		[Display(Name = "Error")]
		Error = 2
	}
}
