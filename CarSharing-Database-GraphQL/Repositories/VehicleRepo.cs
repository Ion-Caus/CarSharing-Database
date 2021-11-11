using System;
using System.Linq;
using System.Threading.Tasks;
using CarSharing_Database_GraphQL.ModelData;
using CarSharing_Database_GraphQL.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CarSharing_Database_GraphQL.Repositories
{
    public class VehicleRepo : IVehicleRepo
    {
        private readonly CarSharingDbContext _dbContext;

        public VehicleRepo(CarSharingDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Vehicle> AddAsync(Vehicle vehicle)
        {
            var added = await _dbContext.Vehicles.AddAsync(vehicle);
            await _dbContext.SaveChangesAsync();
            return added.Entity;
        }

        public async Task<Vehicle> GetAsync(string licenseNo)
        {
            try
            {
                return await _dbContext.Vehicles.FirstAsync(vehicle => vehicle.LicenseNo == licenseNo);
            }
            catch (Exception)
            {
                throw new Exception($"Did not find the vehicle with license number of {licenseNo}");
            }
        }

        public Task<Vehicle> UpdateAsync(Vehicle vehicle)
        {
            throw new NotImplementedException();
        }

        public Task RemoveAsync(string licenseNo)
        {
            throw new NotImplementedException();
        }
    }
}