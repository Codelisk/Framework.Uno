using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Framework.Mvvm.ViewModels;
using Framework.Services.Services.Vms;
using ReactiveUI;

namespace Sample.Presentation;
public partial class BodyViewModel : RegionBaseViewModel
{
    private string test="Test";
    public string Test
    {
        get { return test; }
        set { this.RaiseAndSetIfChanged(ref test, value); }
    }
    public BodyViewModel(VmServices vmServices) : base(vmServices)
    {
    }
    public ICommand NavigateCommand => this.LoadingCommand(OnNavigateAsync);
    private async Task OnNavigateAsync()
    {
        ChangeCurrentRegion("CompanyEntryOverviewView");
    }
}
