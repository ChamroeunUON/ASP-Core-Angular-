using System.Threading.Tasks;
using ASP_Angular.Models;
using Microsoft.EntityFrameworkCore;

namespace ASP_Angular.Persistence
{
    public class VehicleRepository :IVehicleRepository
    {
        private readonly VegaDbContext context;

        public VehicleRepository(VegaDbContext context)
        {
            this.context = context;
        }
        public async Task<Vehicle> GetVehicle(int id){
               return await context.Vehicles
            .Include(f =>  f.Features)
                .ThenInclude(v=>v.Feature)
            .Include(m=>m.Model)   
                .ThenInclude(m=>m.Make)
            .SingleOrDefaultAsync(fid =>fid.Id ==id);
        }
    }
}