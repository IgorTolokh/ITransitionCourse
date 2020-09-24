using Store.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Store.WebUI.Controllers
{
    public class NavController : Controller
    {
        private ICollectionRepository repository;

        public NavController(ICollectionRepository repo)
        {
            repository = repo;
        }

        public PartialViewResult Menu(string category = null, bool horizontalNav = false)
        {
            ViewBag.SelectedCategory = category;

            IEnumerable<string> categories = repository.Collections
                .Select(collection => collection.Category)
                .Distinct()
                .OrderBy(x => x);

            string viewName = horizontalNav ? "MenuHorizontal" : "Menu";
            return PartialView(viewName, categories);
        }
    }
}