using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Services.Services.Application
{
    public interface IMainWindowProvider<T> where T : class
    {
        public T MainWindow { get; }
    }
}
