using Ksiegarnia.Data;
using Ksiegarnia.Data.Services;
using Ksiegarnia.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Ksiegarnia.Controllers
{
    public class GatunekController : Controller
    {
        private readonly IGatunekService _service;

        public GatunekController(IGatunekService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var allGatunek = await _service.GetAll();
            return View(allGatunek);
        }


        //Get: Klienci/Create

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Gatunek_ksiazki")] Gatunek gatunek)
        {
            if (!ModelState.IsValid)
            {
                return View(gatunek);
            }
            _service.Add(gatunek);
            return RedirectToAction(nameof(Index));
        }

        //Get: Gatunek/Edit

        public async Task<IActionResult> Edit(int id)
        {
            var ksiazkaDetails = await _service.GetById(id);
            if (ksiazkaDetails == null) return View("NotFound");
            return View(ksiazkaDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Gatunek gatunek)
        {
            gatunek.Id_gatunek = id;
            if (!ModelState.IsValid)
            {
                return View(gatunek);
            }
            await _service.UpdateAsync(id, gatunek);
            return RedirectToAction(nameof(Index));
        }

        //Get: Gatunek/Delete/1

        public async Task<IActionResult> Delete(int id)
        {
            var ksiazkaDetails = await _service.GetById(id);
            if (ksiazkaDetails == null) return View("NotFound");
            return View(ksiazkaDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfrimed(int id)
        {
            var ksiazkaDetails = await _service.GetById(id);
            if (ksiazkaDetails == null) return View("NotFound");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
