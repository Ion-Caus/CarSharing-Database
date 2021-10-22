namespace CarSharing_Database.ModelData
{
    public class Vehicle
    {
        public string LicenseNo { get; set; }
        public  string Brand { get; set; }
        public  string Model { get; set; }
        public string Type { get; set; }
        public  string Transmission { get; set; }
        public  string FuelType { get; set; }
        public int Seats { get; set; }
        public int ManufactureYear { get; set; }
        public double Mileage { get; set; }
        
        public int OwnerCpr { get; set; }
    }
    
    public static class VehicleTransmission
    {
        public const string Manual = "Manual transmission";
        public const string Automatic = "Automatic transmission";
    }

    public static class VehicleType
    {
        public const string Van = "Van";
        public const string Suv = "SUV";
    }

    public static class VehicleFuelType
    {
        public const string Electric = "Electic";
        public const string Diesel = "Diesel";
        public const string Petrol = "Petrol";
    }

}