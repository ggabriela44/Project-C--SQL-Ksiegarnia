using Ksiegarnia.Models;
using Microsoft.EntityFrameworkCore;

namespace Ksiegarnia.Data.Services
{
    public class KlienciService : IKlienciService
    {
        private readonly KsiegarniaDbContext _context;
        public KlienciService(KsiegarniaDbContext context)
        {
            _context = context;
        }
        public void Add(Klient klient)
        {
            _context.Klient.Add(klient);
            _context.SaveChanges();
        }

        public async Task DeleteAsync(int id)
        {
            var result = await _context.Klient.FirstOrDefaultAsync(n => n.Id_klient == id);
            _context.Klient.Remove(result);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Klient>> GetAll()
        {
            var result = await _context.Klient.ToListAsync();
            return result;
        }

        public async Task<Klient> GetById(int id)
        {
            var result = await _context.Klient.FirstOrDefaultAsync(n => n.Id_klient == id);
            return result;
        }

        public async Task<Klient> UpdateAsync(int id, Klient newklient)
        {
            _context.Update(newklient);
            await _context.SaveChangesAsync();
            return newklient;
        }
    }
}
