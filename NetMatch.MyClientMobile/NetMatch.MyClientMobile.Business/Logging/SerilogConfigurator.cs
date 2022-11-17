using System;
using System.Reflection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Serilog;
using Serilog.Exceptions;
using Serilog.Exceptions.Core;
using Serilog.Sinks.GoogleCloudLogging;

namespace NetMatch.MyClientMobile.Business.Logging
{
    public static class SerilogConfigurator
    {
        public static void Configure(
                    LoggerConfiguration serilogConfiguration,
                    IConfiguration appConfiguration,
                    IServiceProvider serviceProvider,
                    string environment)
        {
            var settings = serviceProvider.GetRequiredService<IOptions<SerilogCustomizationOptions>>().Value;

            serilogConfiguration
                .ReadFrom.Configuration(appConfiguration)
                .ReadFrom.Services(serviceProvider);

            serilogConfiguration
                .WriteTo.Debug()
                .Enrich.FromLogContext()
                .Enrich.WithProperty("ApplicationGroup", settings.ApplicationGroup)
                .Enrich.WithProperty("ApplicationName", settings.ApplicationName)
                .Enrich.WithProperty("Environment", environment)
                .Enrich.WithExceptionDetails(new DestructuringOptionsBuilder().WithDefaultDestructurers());


            if (settings.StackDriver?.Enabled == true)
            {
                var config = new GoogleCloudLoggingSinkOptions
                {
                    ProjectId = settings.StackDriver.ProjectId,
                    LogName = "Default",
                    ServiceName = settings.ApplicationName,
                    ServiceVersion = typeof(SerilogConfigurator)
                        .Assembly
                        .GetCustomAttribute<AssemblyInformationalVersionAttribute>()?
                        .InformationalVersion,
                    UseSourceContextAsLogName = true
                };

                serilogConfiguration.WriteTo.GoogleCloudLogging(config);
            }

            if (settings.Console?.Enabled == true)
            {
                serilogConfiguration.WriteTo.Console(outputTemplate: "{Timestamp:HH:mm:ss} [{Level:u3}] [{SourceContext}] {Message}{NewLine}{Exception}");
            }
        }
    }
}
