using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Mvvm.ViewModels;
using Framework.Services.Services.Vms;

namespace Sample.Presentation;
public partial class HeaderViewModel : RegionBaseViewModel
{
    public HeaderViewModel(VmServices vmServices) : base(vmServices)
    {
    }
}
