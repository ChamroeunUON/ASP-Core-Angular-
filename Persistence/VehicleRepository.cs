using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ASP_Angular.Core;
using ASP_Angular.Core.Models;
using ASP_Angular.Extensions;
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
        public async Task<IEnumerable<Vehicle>> GetVehicles (VehicleQuery queryObj) {
            var query = context.Vehicles
                .Include (model => model.Model)
                .ThenInclude (make => make.Make)
                .Include (v => v.Features)
                .ThenInclude (f => f.Feature)
                .AsQueryable ();

            if (queryObj.MakeId.HasValue)
                query = query.Where (v => v.Model.MakeId == queryObj.MakeId.Value);
            if (queryObj.ModelId.HasValue)
                query = query.Where (m => m.ModelId == queryObj.ModelId.Value);

            var columnMap = new Dictionary<string, Expression<Func<Vehicle, object>> > () {
                    ["make"] = v => v.Model.Make.Name, ["model"] = v => v.Model.Name, ["contactName"] = v => v.ContactName, ["id"] = v => v.Id
                };
            // if(queryObj.SortBy == "make")
            //     query = (queryObj.IsSortByAccending) ? query.OrderBy(v=>v.Model.Make.Name):
            //     query.OrderByDescending(v=>v.Model.Name);
            // if(queryObj.SortBy=="model")
            //     query = (queryObj.IsSortByAccending) ? query.OrderBy(v=>v.Model.Name):
            //     query.OrderByDescending(v=>v.Model.Name);
            // if(queryObj.SortBy == "contactName")
            //     query = (queryObj.IsSortByAccending) ? query.OrderBy(v=> v.ContactName) :
            //     query.OrderByDescending(v=>v.ContactName);
            // if(queryObj.SortBy == "id")
            //     query = (queryObj.IsSortByAccending) ? query.OrderBy(v=> v.Id):
            //     query.OrderByDescending(v=>v.Id);
            query = query.ApplyOrdering (queryObj, columnMap);
           query = query.ApplyPaging(queryObj);
            return await query.ToListAsync ();

        }

        public void Add (Vehicle vehicle) {
            context.Vehicles.Add (vehicle);
        }
        public void Remove (Vehicle vehicle) {
            context.Vehicles.Remove (vehicle);
        }
    }
}