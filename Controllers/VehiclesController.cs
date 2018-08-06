using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASP_Angular.Controllers.Resources;
using ASP_Angular.Core;
using ASP_Angular.Core.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ASP_Angular.Controllers {
    [Route ("api/vehicles")]
    public class VehiclesController : Controller {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;
        private readonly IVehicleRepository repository;

        public VehiclesController (IMapper mapper,IUnitOfWork unitOfWork,IVehicleRepository repository) {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
            this.repository = repository;
        }

        [HttpPost]
        public async Task<IActionResult> CreatVehicle ([FromBody] SaveVehicleResource vehicleResorce) {
            // throw new Exception();
            if (!ModelState.IsValid)
                return BadRequest (ModelState);

            var vehicle = mapper.Map<SaveVehicleResource, Vehicle> (vehicleResorce);
            vehicle.LastUpdate = DateTime.Now;
            repository.Add(vehicle);
            await unitOfWork.CompleteAsync();

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

            await unitOfWork.CompleteAsync();
            vehicle = await repository.GetVehicle(vehicle.Id);
            var result = mapper.Map<Vehicle, VehicleResource> (vehicle);
            return Ok (result);
        }

        [HttpDelete ("{id}")]
        public async Task<IActionResult> DeleteVehicle (int id) {
            var vehicle = await repository.GetVehicle(id,includeRelated:false);
            if (vehicle == null)
                return NotFound ();
            repository.Remove(vehicle);
            await unitOfWork.CompleteAsync();
            return Ok (id);
        }

        [HttpGet ("{id}")]
        public async Task<IActionResult> GetVihecle (int id) {
            var vehicle = await repository.GetVehicle (id,includeRelated:true);
            if (vehicle == null)
                return NotFound ();
            var vehicleResource = mapper.Map<Vehicle, VehicleResource> (vehicle);
            return Ok (vehicleResource);
        }

        [HttpGet]
        public async Task<QuerResultResource<VehicleResource>> GetVehicles(VehicleQueryResource filterResource){
                var filter = mapper.Map<VehicleQueryResource,VehicleQuery>(filterResource);
                var queryResult = await repository.GetVehicles(filter);
                return mapper.Map<QueryResult<Vehicle>,QuerResultResource<VehicleResource>>(queryResult);
        }

    }
}