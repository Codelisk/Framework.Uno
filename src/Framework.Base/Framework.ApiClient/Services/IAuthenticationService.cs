using Framework.ApiClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.ApiClient.Services
{
    public interface IAuthenticationService
    {
        ValueTask<AuthResult> AuthenticateAndCacheTokenAsync(AuthPayload auth);
        ValueTask<bool> RefreshAndCacheTokenAsync();
        ValueTask<AuthResult> RegisterAsync(string email, string password);
        ValueTask<bool> IsAuthenticatedAsync();
    }
}
