using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Store.Abstract;
using Store.Entities;
using Store.WebUI.Models;

namespace Store.WebUI.Controllers
{
    public class CollectionController : Controller
    {
        private ICollectionRepository repository;
        public int pageSize = 10;
        public CollectionController(ICollectionRepository repo)
        {
            repository = repo;
        }
        public ViewResult Index(int collectionId)
        {
            CollectionsListViewModel model = new CollectionsListViewModel
            {
                Collections = repository.Collections
                    .Where(p => p.CollectionId == collectionId)
            };
            return View(model);
        }
        public ViewResult List(string category, string searchString = "", int page = 1)
        {
            CollectionsListViewModel model = new CollectionsListViewModel
            {
                Collections = repository.Collections
                    .Where(p => p.Name.Contains(searchString))
                    .Where(p => category == null || p.Category == category)
                    .OrderBy(collection => collection.CollectionId)
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    TotalItems = category == null ?
                    repository.Collections.Count() :
                    repository.Collections.Where(icollection => icollection.Category == category).Count()
                },
                CurrentCategory = category
            };
            return View(model);
        }
    }
}