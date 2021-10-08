using Server.Entityes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Server.Manager
{
    public interface IFormDataManager
    {
        Task<FormData> GetForm(int id);
        Task<bool> Remove(int id);
        Task<FormData> Add(FormData model);
        Task<List<FormData>> GetAll();
    }
}
