using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Services.Services.Application;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.UI.Xaml.Automation.Provider;
using Uno.Extensions.Markup.Generator;
using Uno.Resizetizer;

namespace Framework.UnoNative
{
    public abstract partial class BaseApp : PrismApplication
    {
        protected override void ConfigureWindow(Window window)
        {
            base.ConfigureWindow(window);

#if DEBUG
            window.EnableHotReload();
#endif
            window.SetWindowIcon();
        }
    }
}
