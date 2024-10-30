using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Disposables;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Framework.Mvvm.Constants;
using Framework.Services.Models;
using Framework.Services.Services.Vms;

namespace Framework.Mvvm.ViewModels
{
    public partial class RegionBaseViewModel
        : BaseLifecycleVm<NavigationContext>,
            IRegionAware,
            IRegionMemberLifetime
    {
        public IRegionNavigationService CurrentRegionNavigationService;
        public virtual bool KeepAlive
        {
            get { return false; }
        }

        private bool Initialized = false;
        private readonly VmServices _vmServices;

        public RegionBaseViewModel(VmServices vmServices)
        {
            _vmServices = vmServices;
        }

        protected virtual List<RegionNavigationModel> RegionsToUse => null;

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        protected virtual void SetUpReactiveAndEvents() { }

        private CompositeDisposable DestroyWithFromPageViewModel;

        public override void FirstSetup(NavigationContext navigationContext) { }

        public override void Initialize(NavigationContext navigationContext)
        {
            this.FirstSetup(navigationContext);

            if (RegionsToUse is not null)
            {
                foreach (var region in RegionsToUse)
                {
                    _vmServices.RegionManager.RequestNavigate(
                        region.RegionName,
                        region.RegionView,
                        region.Parameters
                    );
                }
            }
        }

        public override void OnNavigatedFrom(NavigationContext navigationContext)
        {
            if (!KeepAlive)
            {
                this.Initialized = false;
                Destroy();
            }
        }

        public override void OnNavigatedTo(NavigationContext navigationContext)
        {
            if (this.Initialized)
            {
                return;
            }

            this.Initialize(navigationContext);
            CurrentRegionNavigationService = navigationContext.NavigationService;

            SetUpReactiveAndEvents();

            this.Initialized = true;
            this.IsBusy = false;
        }

        protected virtual INavigationParameters AddBaseValuesToParametersForNavigationToRegion(
            INavigationParameters parameters
        )
        {
            if (parameters is null)
            {
                parameters = new NavigationParameters();
            }
            parameters.Add(
                NavigationParameterKeys.DestroyWithFromPageViewModel,
                this.DestroyWithFromPageViewModel
            );
            return parameters;
        }

        protected void ChangeCurrentRegion(string view, INavigationParameters parameters = null)
        {
            this.CurrentRegionNavigationService.RequestNavigate(
                view,
                this.AddBaseValuesToParametersForNavigationToRegion(parameters)
            );
        }

        protected void GoRegionBack()
        {
            this.CurrentRegionNavigationService.Journal.GoBack();
        }

        public override void SetUpReactiveAndEvents(NavigationContext navContext) { }

        public override Task InitializeAsync(NavigationContext navContext)
        {
            throw new NotImplementedException();
        }

        public override void Destroy()
        {
            _vmServices.VmContainer.DestroyWith?.Dispose();
        }

        public ICommand BackCommand => this.LoadingCommand(async () => GoRegionBack());
    }
}
