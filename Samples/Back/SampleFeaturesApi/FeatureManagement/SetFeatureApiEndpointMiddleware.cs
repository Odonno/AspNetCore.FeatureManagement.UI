using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using SampleFeaturesApi.FeatureManagement;
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCore.FeatureManagement.UI.Middleware
{
    internal class SetFeatureValuePayload
    {
        public bool Value { get; set; }
    }

    internal class SetFeatureApiEndpointMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly JsonSerializerSettings _jsonSerializationSettings;
        private readonly IServiceScopeFactory _serviceScopeFactory;
        private readonly Settings _settings;

        public SetFeatureApiEndpointMiddleware(RequestDelegate next, IServiceScopeFactory serviceScopeFactory, IOptions<Settings> settings)
        {
            _next = next;
            _serviceScopeFactory = serviceScopeFactory;
            _settings = settings?.Value ?? throw new ArgumentNullException(nameof(settings));
            _jsonSerializationSettings = new JsonSerializerSettings()
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                Converters = new[] { new StringEnumConverter() },
                DateTimeZoneHandling = DateTimeZoneHandling.Local
            };
        }

        public async Task InvokeAsync(HttpContext context)
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            using (var streamReader = new StreamReader(context.Request.Body, Encoding.UTF8))
            {
                var featuresServices = scope.ServiceProvider.GetService<IFeaturesService>();

                string featureName = context.Request.RouteValues["featureName"] as string;

                string jsonBody = await streamReader.ReadToEndAsync();
                var payload = JsonConvert.DeserializeObject<SetFeatureValuePayload>(jsonBody);

                var updatedFeature = await featuresServices.Set(featureName, payload.Value);

                var responseContent = JsonConvert.SerializeObject(updatedFeature, _jsonSerializationSettings);
                context.Response.ContentType = "application/json";

                await context.Response.WriteAsync(responseContent);
            }
        }
    }
}