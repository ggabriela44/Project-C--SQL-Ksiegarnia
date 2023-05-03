using Ksiegarnia.Data;
using Ksiegarnia.Data.Services;
using Ksiegarnia.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Ksiegarnia.Controllers
{
    public class DostawaController : Controller
    {
        private readonly IDostawyService _service;

        public DostawaController(IDostawyService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var allDostawa = await _service.GetAll();
            return View(allDostawa);
        }


        //Get: DOstawa/Create

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Typ,Oplata")] Dostawa dostawa)
        {
            if (!ModelState.IsValid)
            {
                return View(dostawa);
            }
            _service.Add(dostawa);
            return RedirectToAction(nameof(Index));
        }

        //Get: Ksiazki/Edit

        public async Task<IActionResult> Edit(int id)
        {
            var ksiazkaDetails = await _service.GetById(id);
            if (ksiazkaDetails == null) return View("NotFound");
            return View(ksiazkaDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id,Dostawa dostawa)
        {
            dostawa.Id_dostawa = id;
            if (!ModelState.IsValid)
            {
                return View(dostawa);
            }
            await _service.UpdateAsync(id, dostawa);
            return RedirectToAction(nameof(Index));
        }

        //Get: Dostawa/Delete/1

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
