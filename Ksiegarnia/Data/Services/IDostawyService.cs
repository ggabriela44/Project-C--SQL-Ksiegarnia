using Ksiegarnia.Models;

namespace Ksiegarnia.Data.Services
{
    public interface IDostawyService
    {
        Task<IEnumerable<Dostawa>> GetAll();
        Task<Dostawa> GetById(int id);
        void Add(Dostawa dostawa);
        Task<Dostawa> UpdateAsync(int id, Dostawa newdostawa);
        Task DeleteAsync(int id);
    }
}
