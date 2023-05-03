using Ksiegarnia.Models;
namespace Ksiegarnia.Data.Services
{
    public interface IZamowienieService
    {
        Task<IEnumerable<Zamowienie>> GetAllAsync();
        Task<Zamowienie> GetByIdAsync(int id);
        Task AddAsync(Zamowienie zamowienie);
        Task<Zamowienie> UpdateAsync(int id,Zamowienie zamowienie);
        Task DeleteAsync(int id);
    }
}
