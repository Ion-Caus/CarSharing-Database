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
    }
}