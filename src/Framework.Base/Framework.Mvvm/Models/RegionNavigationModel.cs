using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Mvvm.Models;

public record RegionNavigationModel(string RegionName, string RegionView)
{
    public INavigationParameters Parameters { get; set; } = new NavigationParameters();
}
