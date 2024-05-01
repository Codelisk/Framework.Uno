using Framework.ApiClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.ApiClient.Repositories
{
    public interface IAuthRepository
    {
        Task<AuthResult> LoginAsync(AuthPayload request);
        Task<AuthResult> RefreshAsync(string refreshToken);
        Task<AuthResult> RegisterAndLoginAsync(AuthPayload request);
        Task RegisterAsync(AuthPayload request);
    }
}

