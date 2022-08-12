using InterviewTask.Models;
using InterviewTask.Repositories;
using InterviewTask.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InterviewTask.Controllers
{
    public class OrderController : Controller
    {
        private readonly OrderRepository orderRepository;
        private readonly ShoppingCartRepository shoppingCartRepository;
        private readonly ApplicationDbContext context;

        public OrderController()
        {
            orderRepository = new OrderRepository();
            shoppingCartRepository = new ShoppingCartRepository();
            context = new ApplicationDbContext();

        }

        // GET: Order
        [Authorize(Roles ="Customer")]
        public ActionResult Index()
        {
            int customerCode = context.Users.Where(u => u.UserName == User.Identity.Name).SingleOrDefault().CustomerCode;
            OrderHeader orderHeader = orderRepository.GetOrderHeader(customerCode);
            List<OrderDetail> orderDetails = orderRepository.GetOrderDetails(orderHeader.Id);
            OrderViewModel orderViewModel = new OrderViewModel
            { 
               OrderHeader=orderHeader,
               OrderDetail=orderDetails
            };
            return View(orderViewModel);
        }

        [Authorize(Roles = "Customer")]
        public ActionResult CheckOut()
        {
            int customerCode = context.Users.Where(u => u.UserName == User.Identity.Name).SingleOrDefault().CustomerCode;
            string cartId = Session["CartId"].ToString();
            var cartItems = shoppingCartRepository.GetShoppingCartItems(cartId);
            if (cartItems.Count==0)
            {
                ModelState.AddModelError("", "Your cart is empty");
            }
            if (ModelState.IsValid)
            {
                orderRepository.CreateOrder(cartItems, customerCode);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}