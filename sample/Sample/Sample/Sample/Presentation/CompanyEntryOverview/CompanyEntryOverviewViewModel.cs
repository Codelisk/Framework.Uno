using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Framework.Mvvm.ViewModels;
using Framework.Services.Services.Vms;
using Framework.UnoNative.Pages;
using ReactiveUI;

namespace Sample.Presentation.CompanyEntryOverview;
public partial class CompanyEntryOverviewViewModel : RegionBaseViewModel
{
    private List<string> entrys = new List<string> { "C#", "Java" };
    public List<string> Entrys
    {
        get { return entrys; }
        set { this.RaiseAndSetIfChanged(ref entrys, value); }
    }
    public CompanyEntryOverviewViewModel(VmServices vmServices) : base(vmServices)
    {
    }
    public ICommand DetailCommand => this.LoadingCommand(OnDetailAsync);
    private async Task OnDetailAsync()
    {
        this.ChangeCurrentRegion("CompanyEntryDetailView");
    }
}
