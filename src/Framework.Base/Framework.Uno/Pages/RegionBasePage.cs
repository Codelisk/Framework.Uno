﻿using Framework.Mvvm.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Uno.Pages
{
    public partial class RegionBasePage : UserControl
    {
        public RegionBasePage()
        {
        }
        public UserControl SetupPage<T>(Action<UserControl, T> configureElement)
        {
            return this.DataContext<RegionBaseViewModel>((page, vm) => page.Content(
                new Grid().Children(
                    new ProgressRing().Width(100).Height(100).Visibility(x => x.Bind(() => vm.IsBusy).Convert((x) => x ? Visibility.Visible : Visibility.Collapsed)),
                    new UserControl().DataContext(configureElement)
                    )
                )
            );
        }
    }
}