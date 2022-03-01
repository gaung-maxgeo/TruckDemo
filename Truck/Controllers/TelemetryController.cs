using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TruckAPI.Models;

namespace TruckAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TelemetryController : ControllerBase
    {
        private readonly TruckDemoContext _context;

        public TelemetryController(TruckDemoContext context)
        {
            _context = context;
        }

        //GET: api/Trucks
        [HttpGet("GetTelemetries")]
        public async Task<ActionResult<IEnumerable<Telemetry>>> GetTelemetries()
        {
            //await Task.Delay(3000);
            return await _context.Telemetries.ToListAsync();
        }


        // GET: api/GetTelemetriesByTruckId/2
        [HttpGet("GetTelemetriesByTruckId/{TruckId}")]
        public async Task<ActionResult<IEnumerable<Telemetry>>> GetTelemetryDetails(string TruckId)
        {

            var Telemetry = await _context.Telemetries
                                            .Include(p => p.Truck)
                                            .Where(tel => tel.TruckId == Convert.ToInt32(TruckId)).ToListAsync();
            if (Telemetry == null)
            {
                return NotFound();
            }

            return Telemetry;
        }


        // POST: api/CreateTelemetries
        [HttpPost("CreateTelemetries")]
        public async Task<ActionResult<Telemetry>> PostTelemetries(Telemetry telemetry)
        {

            _context.Telemetries.Add(telemetry);
            await _context.SaveChangesAsync();

            return await Task.FromResult(telemetry);
        }
    }
}
