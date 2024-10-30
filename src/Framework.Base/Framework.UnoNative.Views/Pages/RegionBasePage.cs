using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Mvvm.ViewModels;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Uno.Extensions.Markup;

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
                {
                    // ProgressRing mit Sichtbarkeitsbindung
                    var progressRing = CreateProgressRing(vm);

                    // Hauptinhalt mit konfiguriertem UserControl
                    var contentControl = new UserControl()
                        .HorizontalAlignment(HorizontalAlignment.Stretch)
                        .Visibility(x =>
                            x.Binding(() => vm.IsBusy)
                                .Convert(isBusy =>
                                    !isBusy ? Visibility.Visible : Visibility.Collapsed
                                )
                        );

                    configureElement(contentControl, vm);

                    page.Assign(out root)
                        .HorizontalAlignment(HorizontalAlignment.Stretch)
                        .Content(new Canvas().Children(progressRing, contentControl));
                }
            );
        }

        private ProgressRing CreateProgressRing(T vm)
        {
            return new ProgressRing()
                .HorizontalAlignment(HorizontalAlignment.Center)
                .Visibility(x =>
                    x.Binding(() => vm.IsBusy)
                        .Convert(isBusy => isBusy ? Visibility.Visible : Visibility.Collapsed)
                );
        }
    }
}
