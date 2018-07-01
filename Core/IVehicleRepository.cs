using System.Threading.Tasks;
using ASP_Angular.Core.Models;

namespace ASP_Angular.Core
{
    public interface IVehicleRepository
    {
         Task<Vehicle> GetVehicle(int id, bool includeRelated=true);
         void Add(Vehicle vehicle);
         void Remove(Vehicle vehicle);


    }
}