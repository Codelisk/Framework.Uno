using Framework.ApiClient.Apis.Base;
using Framework.ApiClient.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.ApiClient.Apis
{
    public partial interface IAuthApi : IBaseApi
    {
        [Post("/login")]
        Task<AuthResult> Login([Body] AuthPayload request);
        [Post("/register")]
        Task<AuthResult> Register([Body] AuthPayload request);
        [Post("/refresh")]
        Task<AuthResult> Refresh([Body] string refreshToken);
    }
}
