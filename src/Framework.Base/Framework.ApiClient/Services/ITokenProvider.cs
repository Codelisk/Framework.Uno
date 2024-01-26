using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.ApiClient.Services
{
    public interface ITokenProvider
    {
        string GetCurrentAccessToken();
        string GetCurrentRefreshToken();
        void UpdateToken(string newToken, string newRefreshToken);
    }
}
