using InterviewTask.Models;
using InterviewTask.Repositories;
using InterviewTask.Repositories.Interfaces;
using InterviewTask.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InterviewTask.Controllers
{
    public class CartController : Controller
    {
        private readonly IShoppingCartRepository shoppingCartRepository;
        private readonly IGenericRepository<Item> genericRepository;
        public CartController()
        {
            shoppingCartRepository = new ShoppingCartRepository();
            genericRepository = new GenericRepository<Item>();
        }
        // GET: Cart
        public ActionResult Index()
        {
           string cartId = Session["CartId"].ToString();
            ShoppingCartViewModel shoppingCartViewModel = new ShoppingCartViewModel
            {
                ShoppingCartItems=shoppingCartRepository.GetShoppingCartItems(cartId),
                ShoppingCartTotal=shoppingCartRepository.GetShoppingCartTotal(cartId)
            };
            return View(shoppingCartViewModel);
        }
        public ActionResult AddToCart(int itemId)
        {
            string cartId = Session["CartId"].ToString();
            var selectedItem = genericRepository.Get(itemId);
            shoppingCartRepository.AddToCart(selectedItem, cartId);
            return RedirectToAction(nameof(Index));
        }
        public ActionResult RemoveFromCart(int id)
        {
            shoppingCartRepository.RemoveFromCart(id);
            return RedirectToAction(nameof(Index));
        }
        public ActionResult ClearCart()
        {
            string cartId = Session["CartId"].ToString();
            shoppingCartRepository.ClearCart(cartId);
            return RedirectToAction(nameof(Index));
        }
    }
}