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
        this.SetupPage<HeaderViewModel>((page, vm) => page.Content(
            new Grid()
            .ColumnDefinitions("*,auto,auto")
            .Children(
                new TextBlock().Text("Header 66"),
            new Button().Content("Login").Grid(1),
            new Button().Content("Sign up").Grid(2)
            )));
    }
}
