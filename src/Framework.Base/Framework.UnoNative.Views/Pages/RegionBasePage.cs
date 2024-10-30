using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Mvvm.ViewModels;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

namespace Framework.UnoNative.Views.Pages
{
    public abstract partial class RegionBasePage<T> : UserControl
        where T : RegionBaseViewModel
    {
        public RegionBasePage()
        {
            this.SetupPage((page, vm) => page.Content(MainContent(vm)));
        }

        protected abstract UIElement MainContent(T vm);
        private UserControl root;

        public T GetDataContext()
        {
            return root.DataContext as T;
        }

        public UserControl SetupPage(Action<UserControl, T> configureElement)
        {
            return this.DataContext<T>(
                (page, vm) =>
                    page.Assign(out root)
                        .HorizontalAlignment(HorizontalAlignment.Stretch)
                        .Content(
                            new Grid()
                                .HorizontalAlignment(HorizontalAlignment.Stretch)
                                .Children(
                                    new ProgressRing().Visibility(x =>
                                        x.Binding(() => vm.IsBusy)
                                            .Convert(
                                                (x) => x ? Visibility.Visible : Visibility.Collapsed
                                            )
                                    ),
                                    new UserControl()
                                        .DataContext(configureElement)
                                        .HorizontalAlignment(HorizontalAlignment.Stretch)
                                )
                        )
            );
        }
    }
}
