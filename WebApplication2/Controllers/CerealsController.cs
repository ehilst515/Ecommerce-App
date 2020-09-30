using ECommerceApp.Models;
using ECommerceApp.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ECommerceApp.Controllers
{
    public class CerealsController : Controller
    {
        private readonly ICerealRepository cerealRepository;

        public CerealsController(ICerealRepository cerealRepository)
        {
            this.cerealRepository = cerealRepository;
        }

        // GET: CerealsController
        public ActionResult Index(string sortBy)
        {
            var cereals = cerealRepository.GetCereals(sortBy);
            if (cereals == null)
                return NotFound();

            return View(cereals);
        }

        // GET: CerealsController/Details/5
        public ActionResult Details(int id)
        {
            return View(new List<Cereal>());
        }

        // GET: CerealsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CerealsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CerealsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CerealsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CerealsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CerealsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
