using Framework.ApiClient.Models;
using Framework.ApiClient.Repositories;
using Framework.ApiClient.Services;
using Framework.UnoNative.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.ApiClient;
using Uno.Extensions.Markup.Generator;
using Microsoft.Extensions.Configuration;
using Framework.Services.Services.Application;
using Microsoft.UI.Xaml.Automation.Provider;
using ooeentwickleruno;
using ooeentwickleruno.Infrastructure;

namespace Framework.UnoNative
{
    public partial class BaseApp : PrismApplication
    {
        public static Window _window;
        protected override void ConfigureWindow(Window window)
        {
            _window = window;
            //this.Container.Resolve<IMainWindowProvider<Window>>();
#if DEBUG
            //window.EnableHotReload();
#endif
        }
        protected override void ConfigureHost(IHostBuilder builder)
        {
            builder
                    .UseLogging(configure: (context, logBuilder) =>
                    {
                        // Configure log levels for different categories of logging
                        logBuilder
                            .SetMinimumLevel(
                                context.HostingEnvironment.IsDevelopment() && false ?
                                    LogLevel.Information :
                                    LogLevel.Warning)

                            // Default filters for core Uno Platform namespaces
                            .CoreLogLevel(LogLevel.Warning);

                        // Uno Platform namespace filter groups
                        // Uncomment individual methods to see more detailed logging
                        //// Generic Xaml events
                        //logBuilder.XamlLogLevel(LogLevel.Debug);
                        //// Layout specific messages
                        //logBuilder.XamlLayoutLogLevel(LogLevel.Debug);
                        //// Storage messages
                        //logBuilder.StorageLogLevel(LogLevel.Debug);
                        //// Binding related messages
                        //logBuilder.XamlBindingLogLevel(LogLevel.Debug);
                        //// Binder memory references tracking
                        //logBuilder.BinderMemoryReferenceLogLevel(LogLevel.Debug);
                        //// DevServer and HotReload related
                        //logBuilder.HotReloadCoreLogLevel(LogLevel.Information);
                        //// Debug JS interop
                        //logBuilder.WebAssemblyLogLevel(LogLevel.Debug);

                    }, enableUnoLogging: true)
                    .UseConfiguration(configure: configBuilder =>
                        configBuilder
                            .EmbeddedSource<BaseApp>()
                            .Section<AppConfig>()
                    )
                    // Enable localization (see appsettings.json for supported languages)
                    .UseLocalization()
#if DEBUG
                    .UseHttp()
#endif
                    .UseAuthentication(auth =>
        auth.AddCustom(custom =>
                custom.Login(
                        async (sp, dispatcher, tokenCache, credentials, cancellationToken) =>
                        {
                            var auth = sp.GetService<IAuthRepository>();
                            var tokenProvider = sp.GetService<ITokenProvider>();
                            credentials.TryGetValue("email", out var email);
                            credentials.TryGetValue("password", out var password);
                            var authenticated = await auth.LoginAsync(new AuthPayload { email = email, password = password });
                            tokenProvider.UpdateToken(authenticated.accessToken, authenticated.refreshToken);
                            credentials["AccessToken"] = authenticated.accessToken;
                            credentials["RefreshToken"] = authenticated.refreshToken;
                            return credentials;
                        })
                    .Refresh(async (sp, tokenCache, credentials, cancellationToken) =>
                    {
                        var tokenProvider = sp.GetService<ITokenProvider>();
                        var token = await tokenCache.AccessTokenAsync();
                        var rToken = await tokenCache.RefreshTokenAsync();
                        tokenProvider.UpdateToken(token, rToken);
                        return default;
                    }), name: "CustomAuth")
                    )
                    .ConfigureServices((context, services) =>
                    {
                        var configuration = context.Configuration;
                        services.AddSingleton<IMainWindowProvider<Window>, MainWindowProvider>();
                        RegisterServices(configuration, services);
                        // TODO: Register your services
                        //services.AddSingleton<IMyService, MyService>();
                    });
        }
        protected virtual void RegisterServices(IConfiguration configuration, IServiceCollection services)
        {
            services.AddSingleton<IDispatcher, Dispatcher>();
        }
        protected override UIElement CreateShell()
        {
            return Container.Resolve<Shell>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<Shell, ShellViewModel>();
        }

    }
}