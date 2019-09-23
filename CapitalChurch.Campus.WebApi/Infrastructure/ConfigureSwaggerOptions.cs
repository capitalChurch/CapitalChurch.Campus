using System;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace CapitalChurch.Campus.WebApi.Infrastructure
{
    public class ConfigureSwaggerOptions : IConfigureOptions<SwaggerGenOptions>
    {
        private readonly IApiVersionDescriptionProvider provider;

        public ConfigureSwaggerOptions(IApiVersionDescriptionProvider provider) => this.provider = provider;

        public void Configure(SwaggerGenOptions options)
        {
            foreach (var description in provider.ApiVersionDescriptions)
                options.SwaggerDoc(description.GroupName, CreateInfoForApiVersion(description));
        }

        private static Info CreateInfoForApiVersion(ApiVersionDescription description)
        {
            var abacate = Environment.GetEnvironmentVariable("kevyn");
            
            var info = new Info()
            {
                Title = "Capital Church - Campus api",
                Version = description.ApiVersion.ToString(),
                Description = "A application to list and manage the Campus of Capital Church",
                Contact = new Contact() { Name = $"Kevyn Klava {abacate}", Email = "kevynsax@gmail.com" },
                TermsOfService = "Shareware",
                License = new License() { Name = "MIT", Url = "https://opensource.org/licenses/MIT" },
            };

            if (description.IsDeprecated)
            {
                info.Description += " This API version has been deprecated.";
            }

            return info;
        }
    }
}