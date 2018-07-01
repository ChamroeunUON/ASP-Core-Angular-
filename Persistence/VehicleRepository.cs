using System.Threading.Tasks;
using ASP_Angular.Core;
using ASP_Angular.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace ASP_Angular.Persistence {
    public class VehicleRepository : IVehicleRepository {
        private readonly VegaDbContext context;

        public VehicleRepository (VegaDbContext context) {
            this.context = context;
        }
        public async Task<Vehicle> GetVehicle (int id, bool includeRelate = true) {
            if (!includeRelate)
                return await context.Vehicles.FindAsync (id);
            return await context.Vehicles
                .Include (f => f.Features)
                    .ThenInclude (v => v.Feature)
                .Include (m => m.Model)
                    .ThenInclude (m => m.Make)
                .SingleOrDefaultAsync (fid => fid.Id == id);
        }
        public void Add (Vehicle vehicle) {
            context.Vehicles.Add (vehicle);
        }
        public void Remove (Vehicle vehicle) {
            context.Vehicles.Remove (vehicle);
        }
    }
}