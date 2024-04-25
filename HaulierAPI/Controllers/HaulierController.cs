using Microsoft.AspNetCore.Mvc;
using TMS_managerAPI.DB;
using SharedData.Models;
using Microsoft.EntityFrameworkCore;

namespace HaulierAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HaulierController : ControllerBase
    {
        private readonly ILogger<HaulierController> _logger;
        private readonly HaulierDbContext _context;

        public HaulierController(ILogger<HaulierController> logger, HaulierDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Haulier>>> GetHauliers()
        {
            return await _context.Hauliers.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Haulier>> GetHaulier(int id)
        {
            var haulier = await _context.Hauliers.FindAsync(id);

            if (haulier == null)
            {
                return NotFound();
            }

            return haulier;
        }

        [HttpPost]
        public async Task<ActionResult<Haulier>> PostHaulier(Haulier haulier)
        {
            _context.Hauliers.Add(haulier);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetHaulier), new { id = haulier.Id }, haulier);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutHaulier(int id, Haulier haulier)
        {
            if (id != haulier.Id)
            {
                return BadRequest();
            }

            _context.Entry(haulier).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HaulierExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHaulier(int id)
        {
            var haulier = await _context.Hauliers.FindAsync(id);
            if (haulier == null)
            {
                return NotFound();
            }

            _context.Hauliers.Remove(haulier);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HaulierExists(int id)
        {
            return _context.Hauliers.Any(e => e.Id == id);
        }
    }
}
