using Framework.ApiClient.Apis.Base;
using Framework.ApiClient.Services;
using Polly.Retry;
using Polly;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.ApiClient.Services.Helper;
using System.Net;

namespace Framework.ApiClient.Repositories.Base
{
    [Codelisk.GeneratorAttributes.ApiAttributes.DefaultApiRepository]
    public class BaseAuthRepository<TApi> : BaseRepository<TApi> where TApi : IBaseApi
    {
        private const int MAX_REFRESH_TOKEN_ATTEMPTS = 1;
        protected readonly AsyncRetryPolicy _refreshTokenPolicy;
        private readonly IAuthenticationService _authenticationService;

        public BaseAuthRepository(IAuthenticationService authenticationService, BaseRepositoryContainer baseRepositoryContainer) : base(baseRepositoryContainer)
        {
            _refreshTokenPolicy = Policy
                .HandleInner<ApiException>(ex => ex.StatusCode == HttpStatusCode.Unauthorized || ex.StatusCode == HttpStatusCode.Forbidden)
                .RetryAsync(MAX_REFRESH_TOKEN_ATTEMPTS, RefreshAuthorizationAsync);
            _authenticationService = authenticationService;
        }

        protected override Task<T> TryRequest<T>(Func<Task<T>> func, T defaultValue = default)
        {
            return _refreshTokenPolicy.ExecuteAsync(new Func<Task<T>>(() => base.TryRequest(func, defaultValue)));
        }

        protected override Task JustSend(Func<Task> task)
        {
            return _refreshTokenPolicy.ExecuteAsync(() => base.JustSend(task));
        }

        /// <summary>
        /// Here we refresh the current authorization token
        /// </summary>
        /// <param name="error">Error from refreshToken policy</param>
        /// <param name="attempt">current attempt</param>
        /// <returns>Task</returns>
        protected virtual async Task RefreshAuthorizationAsync(Exception error, int attempt)
        {
            await _authenticationService.RefreshAndCacheTokenAsync().ConfigureAwait(false);
        }
    }
}
