using System;
using System.IO;
using System.Threading.Tasks;
using ASP_Angular.Controllers.Resources;
using ASP_Angular.Core;
using ASP_Angular.Core.Models;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASP_Angular.Controllers {
    [Route ("/api/vehicles/{vehicleId}/photos")]
    public class PhotoController : Controller {
        private readonly IVehicleRepository repository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly IHostingEnvironment host;
        public PhotoController (IHostingEnvironment host, IMapper mapper, IVehicleRepository repository, IUnitOfWork unitOfWork) {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
            this.repository = repository;
            this.host = host;

        }

        [HttpPost]
        public async Task<IActionResult> Upload (int vehicleId, IFormFile file) {
            var vehicle = await repository.GetVehicle (vehicleId, includeRelated : false);
            if (vehicle == null)
                return NotFound ();

            var uploadPhotosPath = Path.Combine (host.WebRootPath, "uploads");
            if (!Directory.Exists (uploadPhotosPath))
                Directory.CreateDirectory(uploadPhotosPath);
            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
            var filePath = Path.Combine (uploadPhotosPath, fileName);

            using (var stream = new FileStream (filePath, FileMode.Create)) {
                await file.CopyToAsync (stream);
            }
            var photo = new Photo { FileName = fileName }; 
            vehicle.Photos.Add (photo);
            await unitOfWork.CompleteAsync ();

            
            return Ok (mapper.Map<Photo, PhotoResource> (photo));
        }
    }
}