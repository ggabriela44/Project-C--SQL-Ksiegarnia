using Ksiegarnia.Models;

namespace Ksiegarnia.Data.Services
{
    public interface IGatunekService
    {
        Task<IEnumerable<Gatunek>> GetAll();
        Task<Gatunek> GetById(int id);
        void Add(Gatunek newgatunek);
        Task<Gatunek> UpdateAsync(int id, Gatunek newgatunenk);
        Task DeleteAsync(int id);
    }
}
