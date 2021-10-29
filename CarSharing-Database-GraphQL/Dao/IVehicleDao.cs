using CarSharing_Database_GraphQL.ModelData;

namespace CarSharing_Database_GraphQL.Dao
{
    public interface IVehicleDao
    {
        Vehicle Create(Vehicle vehicle);
        Vehicle Read(string licenseNo);
        bool Update(Vehicle vehicle);
        bool Delete(string licenseNo);
    }
}