using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Entityes;
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

        public FormDatasController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FormData>>> GetForms() =>
            await _context.Forms.ToListAsync();

        [HttpGet("{id}")]
        public async Task<ActionResult<FormData>> GetFormData(int id)
        {
            var formData = await _context.Forms.FindAsync(id);

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
            _context.Forms.Add(formData);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFormData", new { id = formData.Id }, formData);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFormData(int id)
        {
            var formData = await _context.Forms.FindAsync(id);
            if (formData == null)
                return NotFound();

            _context.Forms.Remove(formData);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
