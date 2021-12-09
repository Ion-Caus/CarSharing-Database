namespace CarSharing_Database_GraphQL.Mutations.Records
{
    public record VehicleKey(string LicenseNo);
    
    public record CustomerKey(string Cpr);
    
    public record ListingKey(int Id);
}