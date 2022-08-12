using InterviewTask.Models;
using InterviewTask.Repositories;
using InterviewTask.Repositories.Interfaces;
using System.Web.Mvc;

namespace InterviewTask.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ProductsController : Controller
    {
        private readonly IGenericRepository<Item> itemRepository;
        private readonly IGenericRepository<UOM> uomRepository;
        public ProductsController()
        {
            itemRepository = new GenericRepository<Item>();
            uomRepository = new GenericRepository<UOM>();
        }
        // GET: Products
        public ActionResult Index()
        {
            var data = itemRepository.GetAll().Include("UOM");
            return View(data);
        }


        // GET: Products/Create
        public ActionResult Create()
        {
            SelectList uomList = new SelectList(uomRepository.GetAll(), "Id", "Name");
            ViewBag.uomList = uomList;
            return View();
        }

        // POST: Products/Create
        [HttpPost]
        public ActionResult Create(Item item)
        {
            if (ModelState.IsValid)
            {
                itemRepository.Add(item);
                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int id)
        {
            SelectList uomList = new SelectList(uomRepository.GetAll(), "Id", "Name");
            ViewBag.uomList = uomList;
            return View(itemRepository.Get(id));
        }

        // POST: Products/Edit/5
        [HttpPost]
        public ActionResult Edit(Item item)
        {
            if (ModelState.IsValid)
            {
                itemRepository.Edit(item);
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Delete(int id)
        {
            if (ModelState.IsValid)
            {
                itemRepository.Delete(id);
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
