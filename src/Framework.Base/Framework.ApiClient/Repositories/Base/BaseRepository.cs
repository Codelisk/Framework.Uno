using Codelisk.GeneratorAttributes.WebAttributes.HttpMethod;
using Framework.ApiClient.Apis.Base;
using Framework.ApiClient.Services.Helper;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.ApiClient.Repositories.Base
{
    public abstract class BaseRepository<TApi> where TApi : IBaseApi
    {
        protected readonly TApi _repositoryApi;

        private readonly ILogger _logger;
        private readonly BaseRepositoryContainer _baseRepositoryContainer;

        protected BaseRepository(BaseRepositoryContainer baseRepositoryContainer)
        {
            _repositoryApi = baseRepositoryContainer.ApiBuilder.BuildRestService<TApi>(GetAuthorizationHeaderValueAsync);
            _logger = baseRepositoryContainer.Logger;

            _baseRepositoryContainer = baseRepositoryContainer;
        }


        /// <summary>
        /// Here we provide the Auth token for requests
        /// </summary>
        /// <returns>Current access token</returns>
        protected virtual Task<string> GetAuthorizationHeaderValueAsync(HttpRequestMessage message, CancellationToken token)
        {
            return Task.FromResult(_baseRepositoryContainer.TokenProvider.GetCurrentAccessToken());
        }

        /// <summary>
        /// Do an apu request with Try catch logic and resiciance policy
        /// </summary>
        /// <typeparam name="T">Result type</typeparam>
        /// <param name="func">Api request function</param>
        /// <param name="defaultValue">Default value</param>
        /// <returns>Request result or default value when exception handle</returns>
        [Save]
        [Add]
        [Codelisk.GeneratorAttributes.WebAttributes.HttpMethod.Get]
        [GetLast]
        [GetAll]
        [GetFull]
        [GetAllFull]
        protected virtual async Task<T> TryRequest<T>(Func<Task<T>> func, T defaultValue = default(T))
        {
            var result = await func().ConfigureAwait(false);
            return result;
        }

        [Codelisk.GeneratorAttributes.WebAttributes.HttpMethod.Delete]
        [AddRange]
        protected virtual Task JustSend(Func<Task> task)
        {
            return task.Invoke();
        }
    }
}