using Ksiegarnia.Models;
namespace Ksiegarnia.Data.Services
{
    public interface IKlienciService
    {
        Task<IEnumerable<Klient>> GetAll();
        Task<Klient> GetById(int id);
        void Add(Klient klient);
        Task<Klient> UpdateAsync(int id, Klient newklient);
        Task DeleteAsync(int id);
    }
}
