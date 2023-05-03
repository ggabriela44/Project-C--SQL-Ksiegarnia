using Ksiegarnia.Data;
using Ksiegarnia.Data.Services;
using Ksiegarnia.Models;
using Microsoft.AspNetCore.Mvc;

namespace Ksiegarnia.Controllers
{
    public class KlienciController : Controller
    {
        private readonly IKlienciService _service;

        public KlienciController(IKlienciService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var allDkl = await _service.GetAll();
            return View(allDkl);
        }


        //Get: Klienci/Create

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Imie,Nazwisko,Nr_telefon,Email")]Klient klient)
        {
            if (!ModelState.IsValid)
            {
                return View(klient);
            }
            _service.Add(klient);
            return RedirectToAction(nameof(Index));
        }

        //Get: Klienci/Edit

        public async Task<IActionResult> Edit(int id)
        {
            var ksiazkaDetails = await _service.GetById(id);
            if (ksiazkaDetails == null) return View("NotFound");
            return View(ksiazkaDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Klient klient)
        {
            klient.Id_klient = id;
            if (!ModelState.IsValid)
            {
                return View(klient);
            }
            await _service.UpdateAsync(id, klient);
            return RedirectToAction(nameof(Index));
        }

        //Get: Klienci/Delete/1

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
