using Microsoft.AspNetCore.Mvc;
using TMS_managerAPI.DB;
using SharedData.Models;

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
        public IEnumerable<Haulier> Get()
        {
            return _context.Hauliers;
        }
    }
}
