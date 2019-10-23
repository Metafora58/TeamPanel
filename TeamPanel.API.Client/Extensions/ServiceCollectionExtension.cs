using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using TeamPanel.Api.Client;
using TeamPanel.Api.Client.Contracts;

namespace TeamPanel.API.Client.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddTeamPanelApi(this IServiceCollection services, ApiConfiguration apiConfiguration)
        {
            services.AddScoped<IActivitiesClient>(
                factory => {
                    IActivitiesClient activitiesClient = new ActivitiesClient(apiConfiguration);

                    return activitiesClient;
                }
            );
            return services;
        }

    }
}
