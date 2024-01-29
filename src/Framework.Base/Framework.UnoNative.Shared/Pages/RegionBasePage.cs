using Framework.Mvvm.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.UnoNative.Pages
{
    public partial class RegionBasePage : UserControl
    {
        public RegionBasePage()
        {
        }
        public UserControl SetupPage<T>(Action<UserControl, T> configureElement)
        {
            return this.DataContext<RegionBaseViewModel>((page, vm) => page.HorizontalAlignment(HorizontalAlignment.Stretch).Background("#3702f5").Content(
                new Grid().HorizontalAlignment(HorizontalAlignment.Stretch).Children(
                    new ProgressRing().Width(100).Height(100).Visibility(x => x.Bind(() => vm.IsBusy).Convert((x) => x ? Visibility.Visible : Visibility.Collapsed)),
                    new UserControl().DataContext(configureElement).HorizontalAlignment(HorizontalAlignment.Stretch)
                    )
                )
            );
        }
    }
}