using Store.Abstract;
using Store.Entities;
using Store.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Store.WebUI.Controllers
{
    public class CartController : Controller
    {
        private ICollectionRepository repository;

        public CartController(ICollectionRepository repo)
        {
            repository = repo;
        }

        public ViewResult Checkout()
        {
            return View(new ShippingDetails());
        }

        [HttpPost]
        public ViewResult Checkout(Cart cart, ShippingDetails shippingDetails)
        {
            if (cart.Lines.Count() == 0)
            {
                ModelState.AddModelError("", "Извините, ваша корзина пуста!");
            }

            if (ModelState.IsValid)
            {
                cart.Clear();
                return View("Completed");
            }
            else
            {
                return View(shippingDetails);
            }
        }

        public ViewResult Index(Cart cart, string returnUrl)
        {
            return View(new CartIndexViewModel
            {
                Cart = cart,
                ReturnUrl = returnUrl
            });
        }

        public RedirectToRouteResult AddToCart(Cart cart, int collectionId, string returnUrl)
        {
            Collection collection = repository.Collections
                .FirstOrDefault(g => g.CollectionId == collectionId);

            if (collection != null)
            {
                cart.AddItem(collection, 1);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        public RedirectToRouteResult RemoveFromCart(Cart cart, int gameId, string returnUrl)
        {
            Collection collection = repository.Collections
                .FirstOrDefault(g => g.CollectionId == gameId);

            if (collection != null)
            {
                cart.RemoveLine(collection);
            }
            return RedirectToAction("Index", new { returnUrl });
        }
        public PartialViewResult Summary(Cart cart)
        {
            return PartialView(cart);
        }
    }
}