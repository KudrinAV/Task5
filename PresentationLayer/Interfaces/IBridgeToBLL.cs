using PresentationLayer.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer.Interfaces
{
    public interface IBridgeToBLL
    {
        void CheckFile(FileSystemEventArgs e);
        void Dispose();
    }
}
