using Ksiegarnia.Data;
using Ksiegarnia.Data.Services;
using Ksiegarnia.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Ksiegarnia.Controllers
{
    public class KsiazkiZamowienie : Controller
    {
        private readonly KsiegarniaDbContext _context;

        public KsiazkiZamowienie(KsiegarniaDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var silowniaContext = _context.KsiazkaZamowienie.Include(z => z.ZamowienieID).Include(k => k.KsiazkaID);
            return View(await silowniaContext.ToListAsync());
        }


        //Get: KsiazkiZamowienie/Create
        public IActionResult Create()
        {
            ViewData["KsiazkaID"] = new SelectList(_context.Set<Ksiazka>(), "KsiazkaID", "Id_ksiazka");
            ViewData["ZamowienieID"] = new SelectList(_context.Set<Zamowienie>(), "ZamowienieID", "Id_zamowienia");
            return View();
        }

        // POST: KsiazkiZamowienie/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ZamowienieID,KsiazkaID")] KsiazkaZamowienie nowe)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nowe);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["KsiazkaID"] = new SelectList(_context.Set<Ksiazka>(), "KsiazkaID", "Id_ksiazka", nowe.KsiazkaID);
            ViewData["ZamowienieID"] = new SelectList(_context.Set<Zamowienie>(), "ZamowienieID", "Id_zamowienia", nowe.ZamowienieID);
            return View(nowe);
        }
    }
}
