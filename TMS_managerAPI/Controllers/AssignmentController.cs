using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SharedData.Models;
using SharedData.Result;
using TMS_managerAPI.DB;
using TMS_managerAPI.Utilities;

namespace TMS_managerAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AssignmentController : ControllerBase
    {
        private readonly TMSDbContext _context;

        public AssignmentController(TMSDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Assignment>>> GetAssignments()
        {
            return await _context.Assignments
                .Include(h => h.Haulier)
                .Include(t => t.Truck)
                .Include(d => d.Driver)
                .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Assignment>> GetAssignment(int id)
        {
            var assignment = await _context.Assignments
                .Include(h => h.Haulier)
                .Include(t => t.Truck)
                .Include(d => d.Driver)
                .FirstOrDefaultAsync(a => a.Id == id); ;
                   
            if (assignment == null)
            {
                return NotFound();
            }

            return assignment;
        }

        [HttpGet("tonnage-per-truck-per-day")]
        public ActionResult<IEnumerable<TonnagePerTruckPerDayResult>> GetTonnagePerTruckPerDay(DateTime date)
        {
            var tonnagePerTruckPerDay = _context.Assignments
                .Where(assignment => assignment.ArrivalTime.Date == date.Date && assignment.DepartureTime.Date == date.Date)
                .GroupBy(assignment => new { assignment.TruckId, assignment.ArrivalTime.Date })
                .Select(group => new TonnagePerTruckPerDayResult
                {
                    TruckId = group.Key.TruckId,
                    Date = group.Key.Date,
                    Tonnage = group.Sum(assignment => assignment.NettWeight)
                })
                .ToList();

            return tonnagePerTruckPerDay;
        }

        [HttpGet("average-turn-around-time-per-haulier")]
        public ActionResult<IEnumerable<AverageTurnAroundTimePerHaulierResult>> GetAverageTurnAroundTimePerHaulier()
        {
            var averageTurnAroundTimePerHaulier = _context.Assignments
                .AsEnumerable() 
                .GroupBy(assignment => assignment.HaulierId)
                .Select(group => new AverageTurnAroundTimePerHaulierResult
                {
                    HaulierId = group.Key,
                    AverageTurnAroundTime = TimeSpan.FromHours(group.Average(assignment => (assignment.DepartureTime - assignment.ArrivalTime).TotalHours))

                })
                .ToList();

            return averageTurnAroundTimePerHaulier;
        }


        [HttpGet("average-turn-around-time-per-driver")]
        public ActionResult<IEnumerable<AverageTurnAroundTimePerDriverResult>> GetAverageTurnAroundTimePerDriver()
        {
            var averageTurnAroundTimePerDriver = _context.Assignments
                .AsEnumerable()
                .GroupBy(assignment => assignment.DriverId)
                .Select(group => new AverageTurnAroundTimePerDriverResult
                {
                    DriverId = group.Key,
                    AverageTurnAroundTime = TimeSpan.FromHours(group.Average(assignment => (assignment.DepartureTime - assignment.ArrivalTime).TotalHours))

                })
                .ToList();

            return averageTurnAroundTimePerDriver;
        }

        [HttpPost]
        public async Task<ActionResult<Assignment>> PostAssignment( Assignment assignment)
        {
            _context.Assignments.Add(assignment);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAssignment", new { id = assignment.Id }, assignment);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAssignment(int id, Assignment assignment)
        {
            if (id != assignment.Id)
            {
                return BadRequest();
            }

            _context.Entry(assignment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AssignmentExists(id))
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
        public async Task<IActionResult> DeleteAssignment(int id)
        {
            var assignment = await _context.Assignments.FindAsync(id);
            if (assignment == null)
            {
                return NotFound();
            }

            _context.Assignments.Remove(assignment);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AssignmentExists(int id)
        {
            return _context.Assignments.Any(e => e.Id == id);
        }
    }
}
