using System;
using System.Collections.Generic;
using CarSharing_Database_GraphQL.Dao;
using CarSharing_Database_GraphQL.ModelData;
using HotChocolate;

namespace CarSharing_Database_GraphQL.Queries
{
    public class Query
    {
        // private readonly IListingDao _listingDao;
        // private readonly IVehicleDao _vehicleDao;
        //
        // public Query(IListingDao listingDao, IVehicleDao vehicleDao)
        // {
        //     _listingDao = listingDao;
        //     _vehicleDao = vehicleDao;
        // }

        [GraphQLDescription("Get a list of listings by location, dateFrom and dateTo.")]
        public IList<Listing> GetListing([Service] IListingDao listingDao, string location, DateTime dateFrom, DateTime dateTo)
        {
            return listingDao.Read(location, dateFrom, dateTo);
        }

        [GraphQLDescription("Get a vehicle by license number.")]
        public Vehicle GetVehicle([Service] IVehicleDao vehicleDao, string licenseNo)
        {
            return vehicleDao.Read(licenseNo);
        }
    }
}