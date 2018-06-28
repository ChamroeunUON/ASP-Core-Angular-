using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ASP_Angular.Controllers.Resources;
using ASP_Angular.Models;
using ASP_Angular.Persistence;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ASP_Angular.Controllers {
    [Route ("api/vihicles")]
    public class VehiclesController : Controller {
        private readonly IMapper mapper;
        private readonly VegaDbContext context;

        public VehiclesController (IMapper mapper, VegaDbContext context) {
            this.mapper = mapper;
            this.context = context;
        }

        [HttpPost]
        public async Task<IActionResult> CreatVehicle ([FromBody] SaveVehicleResource vehicleResorce) {

            if (!ModelState.IsValid)
                return BadRequest (ModelState);

            // Check Validation Model Id
            // var modal = await context.Models.FindAsync(vehicleResorce.ModelId);
            // if(modal == null){
            //     ModelState.AddModelError("ModalId","Invalid Modal Id");
            //     return BadRequest(ModelState);
            // }
            var vehicle = mapper.Map<SaveVehicleResource, Vehicle> (vehicleResorce);
            vehicle.LastUpdate = DateTime.Now;
            context.Vehicles.Add (vehicle);
            await context.SaveChangesAsync ();

            var result = mapper.Map<Vehicle, SaveVehicleResource> (vehicle);
            return Ok (result);
        }

        [HttpPut ("{id}")]
        public async Task<IActionResult> UpdateVehicle (int id, [FromBody] SaveVehicleResource vehicleResorce) {

            if (!ModelState.IsValid)
                return BadRequest (ModelState);

            // Check Validation Model Id
            // var modal = await context.Models.FindAsync(vehicleResorce.ModelId);
            // if(modal == null){
            //     ModelState.AddModelError("ModalId","Invalid Modal Id");
            //     return BadRequest(ModelState);
            // }
            var vehicle = await context.Vehicles.Include (v => v.Features).SingleOrDefaultAsync (i => i.Id == id);
            if (vehicle == null)
                return NotFound ();
            mapper.Map<SaveVehicleResource, Vehicle> (vehicleResorce, vehicle);
            vehicle.LastUpdate = DateTime.Now;

            await context.SaveChangesAsync ();

            var result = mapper.Map<Vehicle, SaveVehicleResource> (vehicle);
            return Ok (result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVehicle(int id){
            var vehicle = await context.Vehicles.FindAsync(id);
        if(vehicle == null)
            return NotFound();
        context.Vehicles.Remove(vehicle);
        await context.SaveChangesAsync();
        return Ok(id);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetVihecle(int id){
            var vehicle =await context.Vehicles.Include(f =>  f.Features).SingleOrDefaultAsync(fid =>fid.Id ==id);
            if(vehicle == null)
             return NotFound();
            var vehicleResource = mapper.Map<Vehicle,VehicleResource>(vehicle);
            return Ok(vehicleResource);
        }
    }
}