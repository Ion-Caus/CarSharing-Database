using System.Threading.Tasks;
using CarSharing_Database_GraphQL.ModelData;
using CarSharing_Database_GraphQL.Repositories;
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
        
        public async Task RemoveVehicle([Service] IVehicleRepo vehicleRepo, string licenseNo)
        {
            await vehicleRepo.RemoveAsync(licenseNo);
        }
    }
}