using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Entityes;
using Server.Manager;
using Server.Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Controllers
{
    [ApiController]
    [Route("api/FormData")]
    [EnableCors("All")]
    public class FormDatasController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IFormDataManager _manager;

        public FormDatasController(ApplicationDbContext context, IFormDataManager manager)
        {
            _context = context;
            _manager = manager;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FormData>>> GetForms() =>
            await _manager.GetAll();

        [HttpGet("{id}")]
        public async Task<ActionResult<FormData>> GetFormData(int id)
        {
            var formData = await _manager.GetForm(id);
            return formData == null ? NotFound() : formData;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutFormData(int id, FormData formData)
        {
            if (id != formData.Id)
                return BadRequest();

            _context.Entry(formData).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Forms.Any(e => e.Id == id))
                    return NotFound();
                else
                    throw;
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult> PostFormData(FormData formData)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var result = await _manager.Add(formData);
            return CreatedAtAction("GetFormData", new { id = result.Id }, result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFormData(int id) =>
            await _manager.Remove(id)
                ? NoContent()
                : NotFound();
    }
}
