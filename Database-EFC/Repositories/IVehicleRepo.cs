using System.Threading.Tasks;
using Entity.ModelData;

namespace Database_EFC.Repositories
{
    public interface IVehicleRepo
    {
        Task<Vehicle> AddAsync(Vehicle vehicle);
        Task<Vehicle> GetAsync(string licenseNo);
        Task<Vehicle> UpdateAsync(Vehicle vehicle);
        Task<bool> RemoveAsync(string licenseNo);
    }
}