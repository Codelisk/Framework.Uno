using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.UnoNative.Pages;
using Uno.Toolkit.UI;

namespace Sample.Presentation.CompanyEntryOverview;
public partial class CompanyEntryOverviewView : RegionBasePage<CompanyEntryOverviewViewModel>
{
    protected override UIElement MainContent(CompanyEntryOverviewViewModel vm)
    {
        return new Card().Name("RootCard").Assign(out var card).Style(StaticResource.Get<Style>("ElevatedCardStyle"))
            .HeaderContent("Orderlyze")
            .SubHeaderContent(() => vm.Entrys)
            .SubHeaderContentTemplate<List<string>>(x => ChipGroup(()=>x))
            .SupportingContent("Test 2")
            .SupportingContentTemplate<string>(x =>
            new Button()
            .Content(() => x)
            .Command(y => y.Bind(() => vm.DetailCommand)))
            .MediaContent("https://images4.alphacoders.com/110/1107821.jpg")
            .MediaContentTemplate(() => new Image().Source("https://images4.alphacoders.com/110/1107821.jpg")
                    .VerticalAlignment(VerticalAlignment.Center)
                    .HorizontalAlignment(HorizontalAlignment.Center)
                    .Stretch(Stretch.UniformToFill));

        static ChipGroup ChipGroup(Func<List<string>> list)
        {
            return new ChipGroup()
                .ItemsSource(()=>list)
                .Style(StaticResource.Get<Style>("ElevatedFilterChipGroupStyle"))
                .ItemTemplate<string>(title => new TextBlock().Text(() => title));
        }
    }
}
