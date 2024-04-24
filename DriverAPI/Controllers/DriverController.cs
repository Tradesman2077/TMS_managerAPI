using Microsoft.AspNetCore.Mvc;
using TMS_managerAPI.DB; 
using SharedData.Models;
using Microsoft.EntityFrameworkCore;

namespace DriverAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DriverController : ControllerBase
    {
        private readonly ILogger<DriverController> _logger;
        private readonly DriverDbContext _context;

        public DriverController(ILogger<DriverController> logger, DriverDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Driver>>> GetAllDrivers()
        {
            return await _context.Drivers.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Driver>> GetDriverById(int id)
        {
            var driver = await _context.Drivers.FindAsync(id);

            if (driver == null)
            {
                return NotFound("No Driver found");
            }

            return driver;
        }

        [HttpGet("license/{licenseNumber}")]
        public async Task<ActionResult<Driver>> GetDriverByLicense(string licenseNumber)
        {
            var driver = await _context.Drivers.FirstOrDefaultAsync(d => d.LicenseNumber == licenseNumber);

            if (driver == null)
            {
                return NotFound("No Driver found");
            }

            return driver;
        }

        [HttpPost]
        public async Task<ActionResult<Driver>> AddDriver(Driver driver)
        {
            _context.Drivers.Add(driver);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetDriverById), new { id = driver.Id }, driver);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDriver(int id, Driver driver)
        {
            if (id != driver.Id)
            {
                return BadRequest();
            }

            _context.Entry(driver).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DriverExists(id))
                {
                    return NotFound("No Driver found");
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDriver(int id)
        {
            var driver = await _context.Drivers.FindAsync(id);
            if (driver == null)
            {
                return NotFound("No Driver found");
            }

            _context.Drivers.Remove(driver);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DriverExists(int id)
        {
            return _context.Drivers.Any(e => e.Id == id);
        }
    }
}

