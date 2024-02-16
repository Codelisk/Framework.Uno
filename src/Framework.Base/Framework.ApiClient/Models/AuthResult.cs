using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.ApiClient.Models
{
    public class AuthResult
    {
        public string tokenType { get; set; }
        public string accessToken { get; set; }
        public int expiresIn { get; set; }
        public string refreshToken { get; set; }
    }
}
