using System.Threading.Tasks;
using CarSharing_Database_GraphQL.ModelData;

namespace CarSharing_Database_GraphQL.Repositories
{
    public interface IVehicleRepo
    {
        Task<Vehicle> AddAsync(Vehicle vehicle);
        Task<Vehicle> GetAsync(string licenseNo);
        Task<Vehicle> UpdateAsync(Vehicle vehicle);
        Task<bool> RemoveAsync(string licenseNo);
    }
}