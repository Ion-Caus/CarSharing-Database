using System.Threading.Tasks;
using Database_EFC.Repositories;
using Entity.ModelData;
using HotChocolate;

namespace CarSharing_Database_GraphQL.Mutations
{
    public partial class Mutation
    {
        public async Task<Vehicle> AddVehicle([Service] IVehicleRepo vehicleRepo, Vehicle vehicle)
        {
            return await vehicleRepo.AddAsync(vehicle);
        }
        
        public async Task<Vehicle> UpdateVehicle([Service] IVehicleRepo vehicleRepo, Vehicle vehicle)
        {
            return await vehicleRepo.UpdateAsync(vehicle);
        }
        
        public async Task<bool> RemoveVehicle([Service] IVehicleRepo vehicleRepo, string licenseNo)
        {
            return await vehicleRepo.RemoveAsync(licenseNo);
        }
    }
}