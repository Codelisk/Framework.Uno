using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.ApiClient.Models;
using Framework.ApiClient.Repositories;
using Framework.ApiClient.Services;

namespace Framework.UnoNative.Services
{
    internal class AuthenticationService : ApiClient.Services.IAuthenticationService
    {
        private const string AuthProvider = "AuthProvider";
        private const string AccessTokenKey = "AccessTokenKey";
        private readonly ITokenProvider _tokenProvider;
        private readonly IDispatcher _dispatcher;
        private readonly Uno.Extensions.Authentication.IAuthenticationService _authenticationService;
        private readonly IAuthRepository _authRepository;

        public AuthenticationService(
            IDispatcher dispatcher,
            IAuthRepository authRepository,
            ITokenProvider tokenProvider
        )
        {
            _dispatcher = dispatcher;
            _authRepository = authRepository;
            _tokenProvider = tokenProvider;
        }

        public async ValueTask<AuthResult> RegisterAsync(string email, string password)
        {
            var authResult = await _authRepository.RegisterAndLoginAsync(
                new AuthPayload() { email = email, password = password }
            );
            return authResult;
        }

        public async ValueTask<AuthResult> AuthenticateAndCacheTokenAsync(AuthPayload auth)
        {
            var authenticated = await _authRepository.LoginAsync(auth);
            _tokenProvider.UpdateToken(authenticated.accessToken, authenticated.refreshToken);
            return authenticated;
        }

        public async ValueTask<bool> RefreshAndCacheTokenAsync()
        {
            var authenticated = await _authRepository.RefreshAsync(
                _tokenProvider.GetCurrentRefreshToken()
            );
            _tokenProvider.UpdateToken(authenticated.accessToken, authenticated.refreshToken);
            return true;
        }

        public async ValueTask<bool> IsAuthenticatedAsync()
        {
            return true;
        }
    }
}
