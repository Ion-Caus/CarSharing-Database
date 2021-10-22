using System;
using CarSharing_Database.ModelData;
using Microsoft.VisualBasic;

namespace CarSharing_Database.Dao
{
    public interface IVehicleDao
    {
        Vehicle Create(Vehicle vehicle);
        Vehicle Read(string licenseNo);
        Vehicle Read(string location, DateTime dateFrom, DateTime dateTo);
        Vehicle Read(string location, DateInterval dateInterval);
        bool Update(Vehicle vehicle);
        bool Delete(string licenseNo);
    }
}