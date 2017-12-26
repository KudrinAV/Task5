using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IWatcherHandler
    {
        void CheckFile(FileSystemEventArgs e);
    }
}
