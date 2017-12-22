using PresentationLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PresentationLayer.ViewModels;
using BLL.Interfaces;
using BLL.Bridges;
using BLL.DTO;
using AutoMapper;
using System.IO;

namespace PresentationLayer.Bridge
{
    public class BridgeToBLL : IBridgeToBLL
    {
        IBridgeToModel _dbConnect;

        public BridgeToBLL()
        {
            _dbConnect = new BridgeToModel();
        }

        public void CheckFile(FileSystemEventArgs e)
        {
            _dbConnect.CheckFile(e);
        }

        public void Dispose()
        {
            _dbConnect.Dispose();
        }
    }
}
