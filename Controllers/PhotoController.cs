using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ASP_Angular.Controllers.Resources;
using ASP_Angular.Core;
using ASP_Angular.Core.Models;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace ASP_Angular.Controllers {
    [Route ("/api/vehicles/{vehicleId}/photos")]
    public class PhotoController : Controller {
        private readonly IVehicleRepository repository;
        private readonly IUnitOfWork unitOfWork;
        private readonly PhotoSettings photoSettings;
        private readonly IMapper mapper;
        private readonly IHostingEnvironment host;
        private readonly int MAX_BYTES = 1 * 1024 * 1024;
        private readonly string[] ACCEPTED_FILE_TYPE = new[]{".jpg",".jpeg",".png"};
        public PhotoController (IHostingEnvironment host, IMapper mapper, IVehicleRepository repository, IUnitOfWork unitOfWork, IOptionsSnapshot<PhotoSettings> options ) {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
           this.photoSettings = options.Value;
            this.repository = repository;
            this.host = host;

        }

        [HttpPost]
        public async Task<IActionResult> Upload (int vehicleId, IFormFile file) {
            var vehicle = await repository.GetVehicle (vehicleId, includeRelated : false);
            if (vehicle == null)return NotFound ();
            if(file.Length > photoSettings.MaxByte) return BadRequest("File size is too mush.");
            if(!photoSettings.IsSupportFile(file.FileName)) return BadRequest("Invalid extention file type.");
                

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