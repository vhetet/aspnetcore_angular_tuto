using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using vega.Controllers.Resources;
using vega.Models;

namespace vega.Controllers
{
    [Route("/api/vehicles")]
    public class VehiclesController : Controller
    {
        private readonly IMapper mapper;
        private readonly VegaContext context;
        public VehiclesController(IMapper mapper, VegaContext context) 
        {
            this.mapper = mapper;
            this.context = context;
        }

        [HttpPost]
        public async Task<IActionResult> CreateVehicle([FromBody] SaveVehicleResource vehicleResource)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            
            var vehicle = mapper.Map<SaveVehicleResource, Vehicle>(vehicleResource);
            vehicle.LastUpdate = DateTime.Now;

            context.Vehicles.Add(vehicle);
            await context.SaveChangesAsync();

            var result = mapper.Map<Vehicle, SaveVehicleResource>(vehicle);

            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateVehicle(int id, [FromBody] SaveVehicleResource vehicleResource)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            
            var vehicle = await context.Vehicles.Include(v => v.Features).SingleOrDefaultAsync(v => v.Id == id);


            if(vehicle == null)
                return NotFound();

            vehicle = mapper.Map<SaveVehicleResource, Vehicle>(vehicleResource);
            vehicle.LastUpdate = DateTime.Now;
            vehicle.Id = id;

            await context.SaveChangesAsync();

            var result = mapper.Map<Vehicle, SaveVehicleResource>(vehicle);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVehicle(int id)
        {
            var vehicle = await context.Vehicles.FindAsync(id);

            if(vehicle == null)
                return NotFound();

            context.Remove(vehicle);
            await context.SaveChangesAsync();
            return Ok(id);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetVehicle(int id)
        {
            var vehicle = await context.Vehicles.Include(v => v.Features).SingleOrDefaultAsync(v => v.Id == id);

            if(vehicle == null)
                return NotFound();

            var result = mapper.Map<Vehicle, SaveVehicleResource>(vehicle);

            return Ok(result);
        }
    }
}