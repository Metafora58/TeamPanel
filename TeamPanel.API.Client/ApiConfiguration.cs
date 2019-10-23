using System;
using System.Collections.Generic;
using System.Text;

namespace TeamPanel.API.Client
{
    public class ApiConfiguration
    {
        public string BaseUrl { get; set; }

        public ApiConfiguration(string baseUrl)
        {
            BaseUrl = baseUrl;
        }
    }
}
