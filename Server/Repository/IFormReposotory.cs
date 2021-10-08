using Server.Entityes;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Repository
{
    public interface IFormReposotory
    {
        IQueryable<FormData> GetFormsAsync();
        Task<FormData> GetFormAsync(int id);
        Task<FormData> UpdateAsync(int id, FormData model);
        Task<FormData> CreateAsync(FormData model);
        Task Delete(FormData id);
    }
}
