using System;
using System.Collections.Generic;
using System.Text;

namespace TeamPanel.API.Client
{
    public class ApiClient
    {
        ApiConfiguration _apiConfiguration;

        public ApiClient(ApiConfiguration apiConfiguration)
        {
            _apiConfiguration = apiConfiguration;

            _baseUrl = apiConfiguration.BaseUrl;
        }

        private string _baseUrl;

        public string BaseUrl
        {
            get { return _baseUrl; }
            set { _baseUrl = value; }
        }
    }
}
