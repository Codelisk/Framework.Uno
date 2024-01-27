//using Framework.UnoNative;

using Framework.UnoNative;
using Sample.Presentation;
using Uno.Extensions.Markup.Generator;
[assembly: GenerateMarkupForAssembly(typeof(PrismApplicationBase))]

namespace Sample;

public class App : BaseApp
{
    protected override void RegisterTypes(IContainerRegistry containerRegistry)
    {
        base.RegisterTypes(containerRegistry);
        containerRegistry.RegisterForNavigation<HeaderView, HeaderViewModel>();
        containerRegistry.RegisterForNavigation<BodyView, BodyViewModel>();
    }
}
