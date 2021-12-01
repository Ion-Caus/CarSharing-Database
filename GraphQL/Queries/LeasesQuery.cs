using System.Collections.Generic;
using System.Threading.Tasks;
using Database_EFC.Repositories;
using Entity.ModelData;
using HotChocolate;

namespace CarSharing_Database_GraphQL.Queries
{
    // Queries for Leases
    public partial class Query
    {
        [GraphQLDescription("Get a lease by id.")]
        public async Task<Lease> GetLease([Service] ILeaseRepo leaseRepo, int id)
        {
            return await leaseRepo.GetAsync(id);
        }
        
        [GraphQLDescription("Get a list of leases for a specific listing's id.")]
        public async Task<IList<Lease>> GetLeaseByListing([Service] ILeaseRepo leaseRepo, int listingId)
        {
            return await leaseRepo.GetByListingAsync(listingId);
        }
    }
}