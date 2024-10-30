using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Services.Models;

namespace Framework.Services.Services.Navigation
{
    public interface INavService
    {
        void RequestNavigate(RegionNavigationModel regionNavigationModel);
    }
}
