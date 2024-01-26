using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.ApiClient.Services.Helper
{
    public record BaseAuthRepositoryContainer(IApiBuilder ApiBuilder,
        ITokenProvider TokenProvider,
        ILogger<BaseRepositoryContainer> Logger)
    : BaseRepositoryContainer(ApiBuilder, TokenProvider, Logger);
}
