using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TeamPanel.API.Settings
{
    public class AppSettings
    {
        private static volatile AppSettings instance;
        private static object syncRoot = new Object();

        /// <summary>
        /// Application settings constructor.
        /// </summary>
        public AppSettings() { }

        /// <summary>
        /// Application setting instance as singleton.
        /// </summary>
        public static AppSettings Instance
        {
            get
            {
                lock (syncRoot)
                {
                    if (instance == null)
                    {
                        instance = new AppSettings();
                    }
                    return instance;
                }
            }
        }

        internal static void Initialize(IConfiguration configuration)
        {
            lock (syncRoot)
            {
                instance = configuration.GetSection("AppSettings").Get<AppSettings>();
            }
        }

        /// <summary>
        /// TeamPanel database connection string.
        /// </summary>
        public string ConnectionString { get; set; }
    }
}
