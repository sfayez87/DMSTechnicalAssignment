using InterviewTask.Models;
using InterviewTask.Repositories;
using InterviewTask.Repositories.Interfaces;
using System.Web.Mvc;

namespace InterviewTask.Controllers
{
    public class ShopController : Controller
    {
        private readonly IGenericRepository<Item> genericRepository;
        public ShopController()
        {
            genericRepository = new GenericRepository<Item>();
        }
        // GET: Shop
        public ActionResult Index()
        {
            return View(genericRepository.GetAll());
        }
    }
}