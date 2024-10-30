using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Services.Models;

namespace Framework.Services.Services.Navigation
{
    internal class NavService : INavService
    {
        private readonly IRegionManager regionManager;

        public NavService(IRegionManager regionManager)
        {
            this.regionManager = regionManager;
        }

        public void RequestNavigate(RegionNavigationModel regionNavigationModel)
        {
            this.regionManager.RequestNavigate(
                regionNavigationModel.RegionName,
                regionNavigationModel.RegionView,
                regionNavigationModel.Parameters
            );
        }
    }
}
