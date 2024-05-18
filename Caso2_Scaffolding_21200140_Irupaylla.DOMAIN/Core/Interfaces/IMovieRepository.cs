using Caso2_Scaffolding_21200140_Irupaylla.DOMAIN.Infrastructure.Data;

namespace Caso2_Scaffolding_21200140_Irupaylla.DOMAIN.Core.Interfaces
{
    public interface IMovieRepository
    {
        Task<bool> Delete(int id);
        Task<bool> DeleteLogic(int id);
        Task<IEnumerable<Movies>> GetAll();
        Task<Movies> GetById(int id);
        Task<bool> Insert(Movies movies);
        Task<bool> Update(Movies movies);
    }
}