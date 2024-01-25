using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Services.Services.Vms
{
    public record VmServices(IRegionManager RegionManager, VmContainer VmContainer);
}
