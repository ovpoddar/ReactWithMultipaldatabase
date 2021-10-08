using Microsoft.EntityFrameworkCore;
using Server.Entityes;
using Server.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Server.Manager
{
    public class FormDataManager : IFormDataManager
    {
        private readonly IFormReposotory _formReposotory;

        public FormDataManager(IFormReposotory formReposotory) => _formReposotory = formReposotory;

        public async Task<FormData> Add(FormData model) =>
            await _formReposotory.CreateAsync(model);

        public Task<List<FormData>> GetAll() =>
            _formReposotory.GetFormsAsync().ToListAsync();

        public Task<FormData> GetForm(int id) => _formReposotory.GetFormAsync(id);

        public async Task<bool> Remove(int id)
        {
            var model = await _formReposotory.GetFormAsync(id);
            if (model is null)
                return false;
            await _formReposotory.Delete(model);
            return true;
        }
    }
}
