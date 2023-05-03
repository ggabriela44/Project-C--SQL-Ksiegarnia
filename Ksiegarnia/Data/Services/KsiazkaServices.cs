using Ksiegarnia.Models;
using Microsoft.EntityFrameworkCore;

namespace Ksiegarnia.Data.Services
{
    public class KsiazkaServices : IKsiazkaService
    {
        private readonly KsiegarniaDbContext _context;
        public KsiazkaServices(KsiegarniaDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Ksiazka ksiazka)
        {
            await _context.Ksiazka.AddAsync(ksiazka);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var result = await _context.Ksiazka.FirstOrDefaultAsync(n => n.Id_ksiazka == id);
            _context.Ksiazka.Remove(result);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Ksiazka>> GetAllAsync()
        {
            var result = await _context.Ksiazka.ToListAsync();
            return result;
        }

        public async Task<Ksiazka> GetByIdAsync(int id)
        {
            var result = await _context.Ksiazka.FirstOrDefaultAsync(n => n.Id_ksiazka == id);
            return result;
        }

        public async Task<Ksiazka> UpdateAsync(int id, Ksiazka newksiazka)
        {
            _context.Update(newksiazka);
            await _context.SaveChangesAsync();
            return newksiazka;
        }
    }
}
