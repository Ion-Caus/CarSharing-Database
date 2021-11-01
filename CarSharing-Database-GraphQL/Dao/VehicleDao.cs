using System;
using System.Collections.Generic;
using System.Linq;
using CarSharing_Database_GraphQL.ModelData;
using CarSharing_Database_GraphQL.Persistence;

namespace CarSharing_Database_GraphQL.Dao
{
    public class VehicleDao: IVehicleDao
    {
        private readonly IList<Vehicle> _vehicles;

        public VehicleDao()
        {
            var fileContext = FileContext.Instance;
            _vehicles = fileContext.Vehicles;
        }
        
        public Vehicle Create(Vehicle vehicle)
        {
            throw new NotImplementedException();
        }

        public Vehicle Read(string licenseNo)
        {
            return _vehicles.First(vehicle =>
                string.Equals(vehicle.LicenseNo, licenseNo, StringComparison.OrdinalIgnoreCase));
        }
        
        public bool Update(Vehicle vehicle)
        {
            throw new NotImplementedException();
        }

        public bool Delete(string licenseNo)
        {
            throw new NotImplementedException();
        }
    }
}