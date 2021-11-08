using CarSharing_Database_GraphQL.ModelData;

namespace CarSharing_Database_GraphQL.Repositories
{
    public interface IVehicleRepo
    {
        Vehicle Add(Vehicle vehicle);
        Vehicle Get(string licenseNo);
        bool Update(Vehicle vehicle);
        bool Remove(string licenseNo);
    }
}