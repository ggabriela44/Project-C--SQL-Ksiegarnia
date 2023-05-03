using Ksiegarnia.Models;
using Microsoft.EntityFrameworkCore;

namespace Ksiegarnia.Data.Services
{
    public class DostawyService : IDostawyService
    {
        private readonly KsiegarniaDbContext _context;
        public DostawyService(KsiegarniaDbContext context)
        {
            _context = context;
        }

        public void Add(Dostawa dostawa)
        {
            _context.Dostawa.Add(dostawa);
            _context.SaveChanges();
        }

        public async Task DeleteAsync(int id)
        {
            var result = await _context.Dostawa.FirstOrDefaultAsync(n => n.Id_dostawa == id);
            _context.Dostawa.Remove(result);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Dostawa>> GetAll()
        {
            var result = await _context.Dostawa.ToListAsync();
            return result;
        }

        public async Task<Dostawa> GetById(int id)
        {
            var result = await _context.Dostawa.FirstOrDefaultAsync(n => n.Id_dostawa == id);
            return result;
        }

        public async Task<Dostawa> UpdateAsync(int id, Dostawa newdostawa)
        {
            _context.Update(newdostawa);
            await _context.SaveChangesAsync();
            return newdostawa;
        }
    }
}
