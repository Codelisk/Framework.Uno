using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.UnoNative.Pages;

namespace Sample.Presentation.CompanyEntryDetail;
public partial class CompanyEntryDetailView : RegionBasePage<CompanyEntryDetailViewModel>
{
    protected override UIElement MainContent(CompanyEntryDetailViewModel vm)
    {
        return new StackPanel().Children(
            new Image().Source("https://i.ibb.co/Gc3yWqF/goodyear.jpg").Stretch(Stretch.UniformToFill),
            new StackPanel().HorizontalAlignment(HorizontalAlignment.Center).Children(
            new TextBlock().Text("Generali Österreich").FontSize(50).HorizontalAlignment(HorizontalAlignment.Center),
            new ChipGroup().ItemsSource(() => vm.Languages)
            .Style(StaticResource.Get<Style>("AssistChipGroupStyle"))
            .ItemTemplate<ProgrammingLanguageDto>(title => new TextBlock().Text(() => title.Name))
            .HorizontalAlignment(HorizontalAlignment.Center),
            new ChipGroup().ItemsSource(() => vm.Frameworks)
            .Style(StaticResource.Get<Style>("AssistChipGroupStyle"))
            .ItemTemplate<ProgrammingLanguageDto>(title => new StackPanel().Orientation(Orientation.Horizontal).VerticalAlignment(VerticalAlignment.Center).Children(
                new Image().Source("https://dataformers.at/wp-content/uploads/2021/09/1_dotnet.svg").Width(50).Height(50).VerticalAlignment(VerticalAlignment.Center),
                new TextBlock().Text(() => title.Name).VerticalAlignment(VerticalAlignment.Center)
                ))
            .HorizontalAlignment(HorizontalAlignment.Center)
            ,new TextBlock().Text(() => vm.Company.Description).HorizontalAlignment(HorizontalAlignment.Center)
            .MaxWidth(800)
            ));
    }
}
