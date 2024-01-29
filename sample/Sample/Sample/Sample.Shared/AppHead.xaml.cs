using Microsoft.UI.Xaml;
using Uno.Extensions.Hosting;
using Uno.Resizetizer;

namespace Sample;
public sealed partial class AppHead : App
{
    /// <summary>
    /// Initializes the singleton application object. This is the first line of authored code
    /// executed, and as such is the logical equivalent of main() or WinMain().
    /// </summary>
    public AppHead()
    {
        this.InitializeComponent();
    }
    protected override void ConfigureApp(IApplicationBuilder builder)
    {
        base.ConfigureApp(builder);
        Resources.Build(r => r.Merged(new AppResources()));
    }
}
