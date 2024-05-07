using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Codelisk.GeneratorAttributes.ApiAttributes;
using Refit;

namespace Framework.ApiClient.Apis.Base
{
    [BaseApi]
    [Headers("Authorization:Bearer", "Access-Control-Allow-Origin: *", "Accept: application/json")]
    public interface IBaseApi { }
}
