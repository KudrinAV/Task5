using PresentationLayer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Models
{
    public class FilterModel
    {
        public IEnumerable<SaleViewModel> Sales { get; set; }
        public SelectList Managers { get; set; }
        public SelectList Products { get; set; }
        public SelectList Dates { get; set; }
    }
}