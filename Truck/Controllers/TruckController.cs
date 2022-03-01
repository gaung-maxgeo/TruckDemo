using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TruckAPI.Models;

namespace TruckAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TrucksController : ControllerBase
    {
        private readonly TruckDemoContext _context;

        public TrucksController(TruckDemoContext context)
        {
            _context = context;
        }

        // POST: api/CreateTrucks
        [HttpPost("CreateTrucks")]
        public async Task<ActionResult<Models.Truck>> PostTrucks(Models.Truck truck)
        {
            _context.Trucks.Add(truck);
            await _context.SaveChangesAsync();

            return await Task.FromResult(truck);
        }

    }
}
