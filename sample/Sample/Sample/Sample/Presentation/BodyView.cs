using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.UnoNative.Pages;

namespace Sample.Presentation;
public partial class BodyView : RegionBasePage
{
    public BodyView()
    {
        this.SetupPage<HeaderViewModel>((page, vm) => page.Content(new StackPanel().Children(
                       new TextBlock().Text("Header"))));
    }
}
