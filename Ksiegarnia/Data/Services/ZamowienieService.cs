using Ksiegarnia.Models;
using Microsoft.EntityFrameworkCore;

namespace Ksiegarnia.Data.Services
{
    public class ZamowienieService : IZamowienieService
    {
        private readonly KsiegarniaDbContext _context;
        public ZamowienieService(KsiegarniaDbContext context)
        {
            _context = context;
        }


        public async Task AddAsync(Zamowienie zamowienie)
        {
            await _context.Zamowienie.AddAsync(zamowienie);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var result = await _context.Zamowienie.FirstOrDefaultAsync(n => n.Id_zamowienia == id);
            _context.Zamowienie.Remove(result);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Zamowienie>> GetAllAsync()
        {
            var result = await _context.Zamowienie.ToListAsync();
            return result;
        }


        public async Task<Zamowienie> GetByIdAsync(int id)
        {
            var result = await _context.Zamowienie.FirstOrDefaultAsync(n => n.Id_zamowienia == id);
            return result;
        }

        public async Task<Zamowienie> UpdateAsync(int id, Zamowienie zamowienie)
        {
            _context.Update(zamowienie);
            await _context.SaveChangesAsync();
            return zamowienie;
        }
    }
}
