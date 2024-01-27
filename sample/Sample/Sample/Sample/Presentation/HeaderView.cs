using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.UnoNative.Pages;

namespace Sample.Presentation;
public partial class HeaderView : RegionBasePage
{
    public HeaderView()
    {
        this.SetupPage<HeaderViewModel>((page, vm) => page.Content(new StackPanel().Children(
                       new TextBlock().Text("Header"))));
    }
}
