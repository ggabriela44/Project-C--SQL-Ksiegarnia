using Ksiegarnia.Models;

namespace Ksiegarnia.Data.Services
{
    public interface IKsiazkaService
    {
        Task<IEnumerable<Ksiazka>> GetAllAsync();
        Task<Ksiazka> GetByIdAsync(int id);
        Task AddAsync(Ksiazka ksiazka);
        Task<Ksiazka> UpdateAsync(int id, Ksiazka newksiazka);
        Task DeleteAsync (int id);
    }
}
