using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SharedData.Models;
using TMS_managerAPI.DB;

namespace TruckAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TruckController : ControllerBase
    {

        private readonly ILogger<TruckController> _logger;
        private readonly TruckDbContext _context;
        public TruckController(ILogger<TruckController> logger, TruckDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Truck>>> GetTrucks()
        {
            return await _context.Trucks.Include(t => t.Haulier).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Truck>> GetTruck(int id)
        {
            var truck = await _context.Trucks
                                     .Include(t => t.Haulier)
                                     .FirstOrDefaultAsync(t => t.Id == id);

            if (truck == null)
            {
                return NotFound();
            }

            return truck;
        }

        [HttpGet("reg/{reg}")]
        public async Task<ActionResult<IEnumerable<Truck>>> GetTruckByReg(string reg)
        {
            var trucks = await _context.Trucks
                                    .Include(t => t.Haulier)
                                    .Where(x => x.Registration == reg)
                                    .ToListAsync();

            if (trucks.Count == 0)
            {
                return NotFound();
            }

            return trucks;
        }

        [HttpGet("haul/{id}")]
        public async Task<ActionResult<IEnumerable<Truck>>> GetTruckByHaulierId(int id)
        {
            var trucks = await _context.Trucks.Where(x => x.Haulier.Id == id).ToListAsync();
            if (trucks == null)
            {
                return NotFound();
            }

            return trucks;
        }
        [HttpPost]
        public async Task<ActionResult<Truck>> PostTruck(Truck truck)
        {
            _context.Trucks.Add(truck);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTruck), new { id = truck.Id }, truck);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutTruck(int id, Truck truck)
        {
            if (id != truck.Id)
            {
                return BadRequest();
            }

            _context.Entry(truck).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TruckExists(id))
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
        public async Task<IActionResult> DeleteTruck(int id)
        {
            var truck = await _context.Trucks.FindAsync(id);
            if (truck == null)
            {
                return NotFound();
            }

            _context.Trucks.Remove(truck);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        private bool TruckExists(int id)
        {
            return _context.Trucks.Any(e => e.Id == id);
        }
    }
}
