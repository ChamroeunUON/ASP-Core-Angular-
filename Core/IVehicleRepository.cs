using System.Collections.Generic;
using System.Threading.Tasks;
using ASP_Angular.Controllers.Resources;
using ASP_Angular.Core.Models;

namespace ASP_Angular.Core
{
    public interface IVehicleRepository
    {
         Task<Vehicle> GetVehicle(int id, bool includeRelated=true);
        Task<IEnumerable<Vehicle>> GetVehicles(Filter filter);
         void Add(Vehicle vehicle);
         void Remove(Vehicle vehicle);


    }
}