using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.UnoNative.Pages;

namespace Sample.Presentation;
public partial class BodyView : RegionBasePage<BodyViewModel>
{
    public BodyView()
    {
    }

    protected override UIElement MainContent(BodyViewModel vm)
    {
        return new Grid().Children(
                new CardContentControl().Style(StaticResource.Get<Style>("ElevatedCardContentControlStyle")).Width(200).Height(200)
                .Content(
                    new Grid().Children(
                    new Image().Source("https://images4.alphacoders.com/110/1107821.jpg")
                    .VerticalAlignment(VerticalAlignment.Center)
                    .HorizontalAlignment(HorizontalAlignment.Center)
                    .Stretch(Stretch.UniformToFill),
                    new Button()
                    .Content(x=>x.Bind(()=>vm.Test))
                    .Command(x=>x.Bind(()=>vm.NavigateCommand))
                    .Style(StaticResource.Get<Style>("ElevatedButtonStyle")).VerticalAlignment(VerticalAlignment.Bottom).Margin(10)
                )));
    }
}
