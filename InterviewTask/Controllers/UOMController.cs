using InterviewTask.Models;
using InterviewTask.Repositories;
using InterviewTask.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InterviewTask.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UOMController : Controller
    {
        private readonly IGenericRepository<UOM> genericRepository;
        public UOMController()
        {
            genericRepository = new GenericRepository<UOM>();
        }
        // GET: UOM
        public ActionResult Index()
        {
            return View(genericRepository.GetAll());
        }


        // GET: UOM/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UOM/Create
        [HttpPost]
        public ActionResult Create(UOM uom)
        {
            if (ModelState.IsValid)
            {
                genericRepository.Add(uom);
                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: UOM/Edit/5
        public ActionResult Edit(int id)
        {
            return View(genericRepository.Get(id));
        }

        // POST: UOM/Edit/5
        [HttpPost]
        public ActionResult Edit(UOM uom)
        {
            if (ModelState.IsValid)
            {
                genericRepository.Edit(uom);
                return RedirectToAction("Index");
            }
            return View();
        }

        // POST: UOM/Delete/5
        public ActionResult Delete(int id)
        {
            if (ModelState.IsValid)
            {
                genericRepository.Delete(id);
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
