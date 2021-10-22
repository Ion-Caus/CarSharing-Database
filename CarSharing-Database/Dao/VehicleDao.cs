using System;
using System.Collections.Generic;
using System.Linq;
using CarSharing_Database.ModelData;
using CarSharing_Database.Persistence;
using Microsoft.VisualBasic;

namespace CarSharing_Database.Dao
{
    public class VehicleDao: IVehicleDao
    {
        private static VehicleDao _instance;

        public static VehicleDao Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new VehicleDao();
                }
                return _instance;
            }
        }
        
        private FileContext _fileContext;
        private IList<Vehicle> _vehicles;

        private VehicleDao()
        {
            _fileContext = FileContext.Instance;
            _vehicles = _fileContext.Vehicles;
        }
        
        public Vehicle Create(Vehicle vehicle)
        {
            throw new NotImplementedException();
        }

        public Vehicle Read(string licenseNo)
        {
            return _vehicles.First(vehicle => vehicle.LicenseNo.Equals(licenseNo));
        }

        public Vehicle Read(string location, DateTime dateFrom, DateTime dateTo)
        {
            throw new NotImplementedException();
        }

        public Vehicle Read(string location, DateInterval dateInterval)
        {
            throw new NotImplementedException();
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