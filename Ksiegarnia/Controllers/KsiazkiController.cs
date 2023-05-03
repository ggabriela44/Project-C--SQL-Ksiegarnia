using Ksiegarnia.Data;
using Ksiegarnia.Data.Services;
using Ksiegarnia.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Ksiegarnia.Controllers
{
    public class KsiazkiController : Controller
    {

        private readonly IKsiazkaService _service;

        public KsiazkiController(IKsiazkaService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var allk = await _service.GetAllAsync();
            return View(allk);
        }

        //Get: Ksiazki/Create
        
        public IActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> Create([Bind("Tytul,Autor,GatunekID,Ocena,Wydawnictwo,Data_wydania,Cena,Opis")] Ksiazka ksiazka)
        {
            if (!ModelState.IsValid)
            {
                return View(ksiazka);
            }
             await _service.AddAsync(ksiazka);
             return RedirectToAction(nameof(Index));
        }

        //GET: Ksiazki/Details/1
        public async Task<IActionResult> Details(int id)
        {
            var ksiazkaDetails = await _service.GetByIdAsync(id);
            if (ksiazkaDetails == null) return View("Not Found");
            return View(ksiazkaDetails);
        }

        //Get: Ksiazki/Edit

        public async Task<IActionResult> Edit(int id)
        {
            var ksiazkaDetails = await _service.GetByIdAsync(id);
            if (ksiazkaDetails == null) return View("NotFound");
            return View(ksiazkaDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Ksiazka ksiazka)
        {
            ksiazka.Id_ksiazka = id;
            if (!ModelState.IsValid)
            {
                return View(ksiazka);
            }
            await _service.UpdateAsync(id, ksiazka);
            return RedirectToAction(nameof(Index));
        }

        //Get: Ksiazki/Delete/1

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
