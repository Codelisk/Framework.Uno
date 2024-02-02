using Framework.Mvvm.ViewModels;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uno.Extensions.Markup.Generator;
[assembly: GenerateMarkupForAssembly(typeof(PrismApplicationBase))]

namespace Framework.UnoNative.Views.Pages
{
    public abstract partial class RegionBasePage<T> : UserControl where T : RegionBaseViewModel
    {
        public RegionBasePage()
        {
            this.SetupPage((page, vm) => page.Content(MainContent(vm)));
        }
        protected abstract UIElement MainContent(T vm);
        public UserControl SetupPage(Action<UserControl, T> configureElement)
        {
            return this.DataContext<T>((page, vm) => page.HorizontalAlignment(HorizontalAlignment.Stretch).Content(
                new Grid().HorizontalAlignment(HorizontalAlignment.Stretch).Children(
                    new ProgressRing().Width(100).Height(100).Visibility(x => x.Bind(() => vm.IsBusy).Convert((x) => x ? Visibility.Visible : Visibility.Collapsed)),
                    new UserControl().DataContext(configureElement).HorizontalAlignment(HorizontalAlignment.Stretch)
                    )
                )
            );
        }
    }
}