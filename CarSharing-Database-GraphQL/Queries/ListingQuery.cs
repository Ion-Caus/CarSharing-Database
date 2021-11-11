using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CarSharing_Database_GraphQL.Repositories;
using CarSharing_Database_GraphQL.ModelData;
using HotChocolate;

namespace CarSharing_Database_GraphQL.Queries
{
    // Queries for Vehicles
    public partial class Query
    {
        [GraphQLDescription("Get a list of listings by location, dateFrom and dateTo.")]
        public async Task<IList<Listing>> GetListing([Service] IListingRepo listingRepo, string location, DateTime dateFrom, DateTime dateTo)
        {
            return await listingRepo.GetAsync(location, dateFrom, dateTo);
        }
        
        
    }
}