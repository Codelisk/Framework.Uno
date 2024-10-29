using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.ApiClient.Models
{
    public record AuthResult(
        string TokenType,
        string AccessToken,
        int ExpiresIn,
        string RefreshToken
    );
}
