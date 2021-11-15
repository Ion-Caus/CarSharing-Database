using System;
using System.Collections.Generic;
using System.Linq;
using Database_EFC.Persistence;
using Entity.ModelData;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace CarSharing_Database_GraphQL
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using (CarSharingDbContext dbContext = new CarSharingDbContext())
            {
                if (!dbContext.Listings.Any())
                {
                    Seed(dbContext);
                }
            }

            CreateHostBuilder(args).Build().Run();
        }

        private static void Seed(CarSharingDbContext dbContext)
        {
            IList<Vehicle> vehicles =
                new List<Vehicle>()
                {
                    new()
                    {
                        Brand = "Tesla",
                        Model = "X",
                        Type = VehicleType.Suv,
                        FuelType = VehicleFuelType.Electric,
                        Transmission = VehicleTransmission.Automatic,
                        Seats = 7,
                        LicenseNo = "XZ01334",
                        ManufactureYear = 2018,
                        Mileage = 50_266,
                        OwnerCpr = "1212901212"
                    },
                    new()
                    {
                        Brand = "BMW",
                        Model = "m3",
                        Type = VehicleType.Sedan,
                        FuelType = VehicleFuelType.Petrol,
                        Transmission = VehicleTransmission.Manual,
                        Seats = 5,
                        LicenseNo = "AB11222",
                        ManufactureYear = 2014,
                        Mileage = 170_335,
                        OwnerCpr = "0101018877"
                    },
                    new()
                    {
                        Brand = "Mercedes-Benz",
                        Model = "CLS",
                        Type = VehicleType.Coupe,
                        FuelType = VehicleFuelType.Diesel,
                        Transmission = VehicleTransmission.Automatic,
                        Seats = 5,
                        LicenseNo = "MK99222",
                        ManufactureYear = 2020,
                        Mileage = 10_866,
                        OwnerCpr = "2010801234"
                    }
                };
            foreach (var vehicle in vehicles)
            {
                dbContext.Add(vehicle);
            }

            IList<Listing> listings =
                new List<Listing>()
                {
                    new()
                    {
                        Vehicle = vehicles[0],
                        ListedDate = new DateTime(2021, 10, 10, 8, 45, 00, DateTimeKind.Utc),
                        Location = "Aarhus",
                        Price = 350.5m,
                        DateFrom = new DateTime(2021, 10, 15, 15, 30, 00, DateTimeKind.Utc), //15 Oct 2021
                        DateTo = new DateTime(2021, 12, 15, 20, 00, 00, DateTimeKind.Utc) //15 Dec 2021
                    },
                    new()
                    {
                        Vehicle = vehicles[1],
                        ListedDate = new DateTime(2021, 10, 24, 21, 15, 00, DateTimeKind.Utc),
                        Location = "Horsens",
                        Price = 200.8m,
                        DateFrom = new DateTime(2021, 10, 24, 15, 30, 00, DateTimeKind.Utc), //24 Oct 2021
                        DateTo = new DateTime(2021, 11, 24, 15, 30, 00, DateTimeKind.Utc) //24 Nov 2021
                    },
                    new()
                    {
                        Vehicle = vehicles[2],
                        ListedDate = new DateTime(2021, 10, 15, 21, 15, 00, DateTimeKind.Utc),
                        Location = "Aarhus",
                        Price = 500m,
                        DateFrom = new DateTime(2021, 10, 15, 22, 00, 00, DateTimeKind.Utc), //15 Oct 2021
                        DateTo = new DateTime(2022, 1, 30, 12, 00, 00, DateTimeKind.Utc) //1 Jan 2022
                    }
                };
            foreach (var listing in listings)
            {
                dbContext.Add(listing);
            }
            dbContext.SaveChanges();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
    }
}