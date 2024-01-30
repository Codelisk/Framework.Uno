using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.UnoNative.Pages;
using ReactiveUI;
using Uno.Toolkit.UI;

namespace Sample.Presentation.CompanyEntryOverview;
public partial class CompanyEntryOverviewView : UserControl
{
    public CompanyEntryOverviewView()
    {
        this.DataContext<CompanyEntryOverviewViewModel>((page, vm) => page.Content(
            new Card().DataContext(() => vm).Style(StaticResource.Get<Style>("ElevatedCardStyle"))
            .HeaderContent("Orderlyze")
            .SupportingContent("Test 2")
            .SupportingContentTemplate<string>(x =>
            new Button()
            .Content(() => x)
            .Command(() => vm.DetailCommand))));
    }
}
