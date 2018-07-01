using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASP_Angular.Controllers.Resources;
using ASP_Angular.Models;
using ASP_Angular.Persistence;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ASP_Angular.Controllers {
    [Route ("api/vehicles")]
    public class VehiclesController : Controller {
        private readonly IMapper mapper;
        private readonly VegaDbContext context;
        private readonly IVehicleRepository repository;

        public VehiclesController (IMapper mapper, VegaDbContext context, IVehicleRepository repository) {
            this.mapper = mapper;
            this.context = context;
            this.repository = repository;
        }

        [HttpPost]
        public async Task<IActionResult> CreatVehicle ([FromBody] SaveVehicleResource vehicleResorce) {
            if (!ModelState.IsValid)
                return BadRequest (ModelState);

            var vehicle = mapper.Map<SaveVehicleResource, Vehicle> (vehicleResorce);
            vehicle.LastUpdate = DateTime.Now;
            context.Vehicles.Add (vehicle);
            await context.SaveChangesAsync ();

            // *** One Way Mapping to resource
            // await context.Models.Include(make=>make.Make).SingleOrDefaultAsync(makeId=>makeId.Id == vehicle.ModelId);
            // await context.Features.ToListAsync();

            // ** Recommentdation Way **//
            vehicle = await repository.GetVehicle (vehicle.Id);
            var result = mapper.Map<Vehicle, VehicleResource> (vehicle);
            return Ok (result);
        }

        [HttpPut ("{id}")]
        public async Task<IActionResult> UpdateVehicle (int id, [FromBody] SaveVehicleResource vehicleResorce) {

            if (!ModelState.IsValid)
                return BadRequest (ModelState);
            var vehicle = await repository.GetVehicle (id);
            if (vehicle == null)
                return NotFound ();
            mapper.Map<SaveVehicleResource, Vehicle> (vehicleResorce, vehicle);
            vehicle.LastUpdate = DateTime.Now;

            await context.SaveChangesAsync ();

            var result = mapper.Map<Vehicle, VehicleResource> (vehicle);
            return Ok (result);
        }

        [HttpDelete ("{id}")]
        public async Task<IActionResult> DeleteVehicle (int id) {
            var vehicle = await context.Vehicles.FindAsync (id);
            if (vehicle == null)
                return NotFound ();
            context.Vehicles.Remove (vehicle);
            await context.SaveChangesAsync ();
            return Ok (id);
        }

        [HttpGet ("{id}")]
        public async Task<IActionResult> GetVihecle (int id) {
            var vehicle = await repository.GetVehicle (id);
            if (vehicle == null)
                return NotFound ();
            var vehicleResource = mapper.Map<Vehicle, VehicleResource> (vehicle);
            return Ok (vehicleResource);
        }

    }
}