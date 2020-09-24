using Store.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;

namespace Store.WebUI.Models
{
    public class CollectionsListViewModel
    {
        public IEnumerable<Collection> Collections { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public string CurrentCategory { get; set; }
    }
}