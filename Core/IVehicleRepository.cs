using System.Collections.Generic;
using System.Threading.Tasks;
using vega.Core.Models;
using Vega.Models;

namespace Vega.Core
{
    public interface IVehicleRepository
    {
        Task<Vehicle> GetVehicle(int id, bool includeRelated = true);
        void Add(Vehicle vehicle);
        void Remove(Vehicle vehicle);
        Task<IEnumerable<Vehicle>> GetVehicles(VehicleQuery filter);
    }
}