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
        this.SetupPage<HeaderViewModel>((page, vm) => page.HorizontalAlignment(HorizontalAlignment.Stretch).Content(
            new ElevatedView().Elevation(10).Background("#ffffff").ElevatedContent(
            new StackPanel().HorizontalAlignment(HorizontalAlignment.Stretch).Children(
            new Grid().HorizontalAlignment(HorizontalAlignment.Stretch).Margin(100,0,100,0)
            .ColumnDefinitions("*,auto,auto")
            .Children(
            new TextBlock().Text("Foodora").FontSize(50).HorizontalAlignment(HorizontalAlignment.Stretch),
            new Button().Content("Login").Grid(1),
            new Button().Content("Sign up").Grid(2)
            )
            ))));
    }
}
