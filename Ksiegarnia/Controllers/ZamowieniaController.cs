using Ksiegarnia.Data;
using Ksiegarnia.Data.Services;
using Ksiegarnia.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Ksiegarnia.Controllers
{
    public class ZamowieniaController : Controller
    {
        private readonly IZamowienieService _service;

        public ZamowieniaController(IZamowienieService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var allOrders = await _service.GetAllAsync();
            return View(allOrders);
        }


        //Get: Zamowienie/Create

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("KlientID, DostawaID, Cena_ksiazek, Cena_dostawy,Typ_zaplaty,Ulica,Nr_domu,Miejscowosc,Kod_pocztowy")] Zamowienie zamowienie)
        {
            if (!ModelState.IsValid)
            {
                return View(zamowienie);
            }
            await _service.AddAsync(zamowienie);
            return RedirectToAction(nameof(Index));
        }

        //GET: Zamowienia/Details/1
        public async Task<IActionResult> Details(int id)
        {
            var zamowienieDetails = await _service.GetByIdAsync(id);
            if (zamowienieDetails == null) return View("Empty");
            return View(zamowienieDetails);
        }
        //Get: Zamowienia/Edit

        public async Task<IActionResult> Edit(int id)
        {
            var zamowienieDetails = await _service.GetByIdAsync(id);
            if (zamowienieDetails == null) return View("NotFound");
            return View(zamowienieDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Zamowienie zamowienie)
        {
            zamowienie.Id_zamowienia = id;
            if (!ModelState.IsValid)
            {
                return View(zamowienie);
            }
            await _service.UpdateAsync(id, zamowienie);
            return RedirectToAction(nameof(Index));
        }


        //Get: Zamowienia/Delete/1

        public async Task<IActionResult> Delete(int id)
        {
            var ksiazkaDetails = await _service.GetByIdAsync(id);
            if (ksiazkaDetails == null) return View("NotFound");
            return View(ksiazkaDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfrimed(int id)
        {
            var ksiazkaDetails = await _service.GetByIdAsync(id);
            if (ksiazkaDetails == null) return View("NotFound");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
