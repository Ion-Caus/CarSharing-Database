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

        public async Task<Vehicle> UpdateAsync(Vehicle vehicle)
        {
            try
            {
                _dbContext.Update(vehicle);
                await _dbContext.SaveChangesAsync();
                return vehicle;
            }
            catch (Exception)
            {
                throw new Exception($"Did not find vehicle with licenseNo #{vehicle.LicenseNo}");
            }
        }
        

        public async Task<bool> RemoveAsync(string licenseNo)
        {
            var toRemove = await _dbContext.Vehicles.FirstOrDefaultAsync(v => v.LicenseNo == licenseNo);
            if (toRemove == null) return false;
            
            _dbContext.Vehicles.Remove(toRemove);
            await _dbContext.SaveChangesAsync();
            return true;

        }
    }
}