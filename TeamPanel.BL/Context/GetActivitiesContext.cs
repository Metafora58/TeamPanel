using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace TeamPanel.BL.Context
{
    [DataContract(Name = "get-activities-context")]
    public class GetActivitiesContext
    {
        [FromQuery(Name = "id")]
        public int? Id { get; set; }
        [FromQuery(Name = "name")]
        public string Name { get; set; }
    }
}
