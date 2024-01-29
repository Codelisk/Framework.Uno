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
            new Grid().Children(
                new Card().Style(StaticResource.Get<Style>("ElevatedCardStyle")).MaxWidth(200).MaxHeight(200)
                .HeaderContent("Test")
                .SubHeaderContent("Test 2")
                .MediaContent("ms-appx:///Assets/salzburg.png")
                .MediaContentTemplate(() => new Image().Width(500).HorizontalAlignment(HorizontalAlignment.Stretch).Stretch(Stretch.UniformToFill).Source(x=>x.Bind()))))));
    }
}
