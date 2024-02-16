using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.ApiClient.Services.Helper
{
    public class ApiBuilder : IApiBuilder
    {
        //private readonly JsonSerializerSettings _jsonSettings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.None };

        public TApi BuildRestService<TApi>(Func<HttpRequestMessage, CancellationToken, Task<string>>? AuthorizationHeaderValueGetter = null)
        {
            return RestService.For<TApi>(GetRestUrl(), BuildApiSettings(AuthorizationHeaderValueGetter));
        }

        /// <summary>
        /// Build api settings
        /// </summary>
        /// <returns>Refit Settings</returns>
        private RefitSettings BuildApiSettings(Func<HttpRequestMessage, CancellationToken, Task<string>>? AuthorizationHeaderValueGetter = null)
        {
            return new RefitSettings
            {
                AuthorizationHeaderValueGetter = AuthorizationHeaderValueGetter,
                ContentSerializer = new NewtonsoftJsonContentSerializer()
            };
        }

        public string GetRestUrl()
        {
            return "https://ooeentwickler.azurewebsites.net/";//Constants.RestUrl;
        }
    }
}
