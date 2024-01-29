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
        return new RichTextBlock();
    }
}
