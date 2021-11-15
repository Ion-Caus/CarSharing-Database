using System;
using System.Threading.Tasks;
using Database_EFC.Repositories;
using Entity.ModelData;
using HotChocolate;

namespace CarSharing_Database_GraphQL.Queries
{
    // Queries for Vehicles
    public partial class Query
    {

        [GraphQLDescription("Get a vehicle by license number.")]
        public async Task<Vehicle> GetVehicle([Service] IVehicleRepo vehicleRepo, string licenseNo)
        {
            return await vehicleRepo.GetAsync(licenseNo);
        }
    }
}