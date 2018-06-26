
using System.Collections.Generic;
using ASP_Angular.Models;
using ASP_Angular.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace ASP_Angular.Controllers
{
    [Route("api/vihicles")]
    public class VehiclesController : Controller
    {
        [HttpPost]
        public IActionResult CreatVehicle([FromBody]Vehicle vehicle){
            return Ok(vehicle);
        }

    }
}