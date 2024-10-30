using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Services.Services.Navigation;
using Microsoft.Extensions.DependencyInjection;

namespace Framework.Services
{
    public static class Initializer
    {
        public static void AddFrameworkServices(this IServiceCollection serviceDescriptors)
        {
            serviceDescriptors.AddScoped<INavService, NavService>();
        }
    }
}
