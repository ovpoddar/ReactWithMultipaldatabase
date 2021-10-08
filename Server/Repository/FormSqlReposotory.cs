using Microsoft.EntityFrameworkCore;
using Server.Entityes;
using Server.Model;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Repository
{
    public class FormSqlReposotory : IFormReposotory
    {
        private readonly ApplicationDbContext _context;

        public FormSqlReposotory(ApplicationDbContext context) =>
            _context = context;

        public async Task<FormData> CreateAsync(FormData model)
        {
            try
            {
                _context.Forms.Add(model);
                await _context.SaveChangesAsync();
                return model;
            }
            catch
            {
                return null;
            }
        }

        public async Task Delete(FormData formData)
        {
            _context.Forms.Remove(formData);
            await _context.SaveChangesAsync();
        }

        public async Task<FormData> GetFormAsync(int id) =>
            await _context.Forms.FindAsync(id);

        public IQueryable<FormData> GetFormsAsync() =>
            _context.Forms.AsQueryable();

        public async Task<FormData> UpdateAsync(int id, FormData formData)
        {
            _context.Entry(formData).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return formData;
        }
    }
}
