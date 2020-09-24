using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Store.Abstract;
using Store.Entities;

namespace Store.WebUI.Controllers
{
    public class AdminController : Controller
    {
        ICollectionRepository repository;

        public AdminController(ICollectionRepository repo)
        {
            repository = repo;
        }

        public ViewResult Index()
        {
            return View(repository.Collections);
        }
        public ViewResult Edit(int collectionId)
        {
            Collection collection = repository.Collections
                .FirstOrDefault(g => g.CollectionId == collectionId);
            return View(collection);
        }

        // Перегруженная версия Edit() для сохранения изменений
        [HttpPost]
        public ActionResult Edit(Collection collection, HttpPostedFileBase image = null)
        {
            if (ModelState.IsValid)
            {
                if (image != null)
                {
                    collection.ImageMimeType = image.ContentType;
                    collection.ImageData = new byte[image.ContentLength];
                    image.InputStream.Read(collection.ImageData, 0, image.ContentLength);
                }
                repository.SaveCollection(collection);
                TempData["message"] = string.Format("Изменения в коллекции \"{0}\" были сохранены", collection.Name);
                return RedirectToAction("Index");
            }
            else
            {
                // Что-то не так со значениями данных
                return View(collection);
            }
        }
        public ViewResult Create()
        {
            return View("Edit", new Collection());
        }
        [HttpPost]
        public ActionResult Delete(int collectionId)
        {
            Collection deletedCollection = repository.DeleteCollection(collectionId);
            if (deletedCollection != null)
            {
                TempData["message"] = string.Format("Коллекция \"{0}\" была удалена",
                    deletedCollection.Name);
            }
            return RedirectToAction("Index");
        }
        public FileContentResult GetImage(int collectionId)
        {
            Collection collection = repository.Collections
                .FirstOrDefault(g => g.CollectionId == collectionId);

            if (collection != null)
            {
                return File(collection.ImageData, collection.ImageMimeType);
            }
            else
            {
                return null;
            }
        }
    }
}