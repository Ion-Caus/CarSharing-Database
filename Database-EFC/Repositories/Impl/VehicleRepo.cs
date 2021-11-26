using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Database_EFC.Persistence;
using Entity.ModelData;
using Logger.Log;
using Microsoft.EntityFrameworkCore;

namespace Database_EFC.Repositories.Impl
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
            Log.AddLog($"|Repositories/VehicleRepo.AddAsync| : Request : {JsonSerializer.Serialize(vehicle)}");
            vehicle.IsDeleted = false;
            var added = await _dbContext.Vehicles.AddAsync(vehicle);
            _dbContext.Attach(vehicle.Owner);
            await _dbContext.SaveChangesAsync();
            return added.Entity;
        }

        public async Task<Vehicle> GetAsync(string licenseNo)
        {
            try
            {
                Log.AddLog($"|Repositories/VehicleRepo.GetAsync| : Request :  LicenseNo:{licenseNo}");
                Vehicle vehicle = await _dbContext.Vehicles
                    .Include(vehicle => vehicle.Owner)
                    .Where(vehicle => !vehicle.IsDeleted)
                    .FirstAsync(vehicle => vehicle.LicenseNo == licenseNo);
                return vehicle;
            }
            catch (Exception e)
            {
                Log.AddLog($"|Repositories/VehicleRepo.GetAsync| : Error : {e.Message}");
                throw new Exception($"Did not find the vehicle with licenseNo of {licenseNo}");
            }
        }

        public async Task<List<Vehicle>> GetByOwnerAsync(string cpr)
        {
            try
            {
                Log.AddLog($"|Repositories/VehicleRepo.GetByOwnerAsync| : Request :  Cpr:{cpr}");
                return await _dbContext.Vehicles
                    .Include(vehicle => vehicle.Owner)
                    .Where(vehicle => !vehicle.IsDeleted)
                    .Where(vehicle => vehicle.Owner.Cpr.Equals(cpr))
                    .ToListAsync();
            }
            catch (Exception e)
            {
                Log.AddLog($"|Repositories/VehicleRepo.GetByOwnerAsync| : Error : {e.Message}");
                throw new Exception($"Cannot retrieve the vehicles owned by the customer with cpr '{cpr}'");
            }
        }

        public async Task<Vehicle> UpdateAsync(Vehicle vehicle)
        {
            try
            {
                _dbContext.Update(vehicle);
                await _dbContext.SaveChangesAsync();
                Log.AddLog($"|Repositories/VehicleRepo.UpdateAsync| : Reply : {JsonSerializer.Serialize(vehicle)}");
                return vehicle;
            }
            catch (Exception e)
            {
                Log.AddLog($"|Repositories/VehicleRepo.UpdateAsync| : Error : {e.Message}");
                throw new Exception($"Did not find vehicle with licenseNo of {vehicle.LicenseNo}");
            }
        }
        

        public async Task<bool> RemoveAsync(string licenseNo)
        {
            var toRemove = await _dbContext.Vehicles.FirstOrDefaultAsync(v => v.LicenseNo.Equals(licenseNo));
            if (toRemove == null) return false;
            try
            {
                Log.AddLog($"|Repositories/VehicleRepo.RemoveAsync| : Request : LicenseNo:{licenseNo}");
                _dbContext.Vehicles.Remove(toRemove);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                Log.AddLog($"|Repositories/VehicleRepo.RemoveAsync| : Error : {e.Message}");
                throw new Exception($"Cannot remove the vehicle with licenseNo #{licenseNo}");
            }

        }
    }
}