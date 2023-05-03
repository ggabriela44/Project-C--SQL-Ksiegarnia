using Ksiegarnia.Models;
using Microsoft.EntityFrameworkCore;

namespace Ksiegarnia.Data.Services
{
    public class GatunekService : IGatunekService
    {
        private readonly KsiegarniaDbContext _context;
        public GatunekService(KsiegarniaDbContext context)
        {
            _context = context;
        }

        public void Add(Gatunek newgatunek)
        {
            _context.Gatunek.Add(newgatunek);
            _context.SaveChanges();
        }

        public async Task DeleteAsync(int id)
        {
            var result = await _context.Gatunek.FirstOrDefaultAsync(n => n.Id_gatunek == id);
            _context.Gatunek.Remove(result);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Gatunek>> GetAll()
        {
            var result = await _context.Gatunek.ToListAsync();
            return result;
        }

        public async Task<Gatunek> GetById(int id)
        {
            var result = await _context.Gatunek.FirstOrDefaultAsync(n => n.Id_gatunek == id);
            return result;
        }

        public async Task<Gatunek> UpdateAsync(int id, Gatunek newgatunenk)
        {
            _context.Update(newgatunenk);
            await _context.SaveChangesAsync();
            return newgatunenk;
        }
    }
}
