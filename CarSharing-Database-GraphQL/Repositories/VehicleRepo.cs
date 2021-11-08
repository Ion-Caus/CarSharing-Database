using System;
using System.Linq;
using CarSharing_Database_GraphQL.ModelData;
using CarSharing_Database_GraphQL.Persistence;

namespace CarSharing_Database_GraphQL.Repositories
{
    public class VehicleRepo: IVehicleRepo
    {
        private readonly CarSharingDbContext _dbContext;

        public VehicleRepo(CarSharingDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public Vehicle Add(Vehicle vehicle)
        {
            throw new NotImplementedException();
        }

        public Vehicle Get(string licenseNo)
        {
            return _dbContext.Vehicles.First(vehicle => vehicle.LicenseNo == licenseNo);
        }
        
        public bool Update(Vehicle vehicle)
        {
            throw new NotImplementedException();
        }

        public bool Remove(string licenseNo)
        {
            throw new NotImplementedException();
        }
    }
}