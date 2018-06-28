
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ASP_Angular.Models;
using ASP_Angular.Persistence;
using ASP_Core_Angular_.Controllers.Resources;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ASP_Angular.Controllers
{
    [Route("api/vihicles")]
    public class VehiclesController : Controller
    {
        private readonly IMapper mapper;
        private readonly VegaDbContext context;

        public VehiclesController(IMapper mapper, VegaDbContext context )
        {
            this.mapper = mapper;
            this.context = context;
        }

        [HttpPost]
        public IActionResult CreatVehicle([FromBody]Vehicle vehicle){
            return Ok(vehicle);
        }

        [HttpPut ("{id}")]
        public async Task<IActionResult> UpdateVehicle (int id, [FromBody] VehicleResource vehicleResorce) {

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
            mapper.Map<VehicleResource, Vehicle> (vehicleResorce, vehicle);
            vehicle.LastUpdate = DateTime.Now;

            await context.SaveChangesAsync ();

            var result = mapper.Map<Vehicle, VehicleResource> (vehicle);
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

    }
}