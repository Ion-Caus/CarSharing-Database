using System;
using System.Threading.Tasks;
using CarSharing_Database_GraphQL.ModelData;
using CarSharing_Database_GraphQL.Mutations.Records;
using CarSharing_Database_GraphQL.Repositories;
using HotChocolate;

namespace CarSharing_Database_GraphQL.Mutations
{
    public partial class Mutation
    {
        public async Task<Listing> AddListing([Service] IListingRepo listingRepo, ListingInput input)
        {
            var listing = new Listing
            {
                ListedDate = input.ListedDate,
                Price = input.Price,
                Location = input.Location,
                DateFrom = input.DateFrom,
                DateTo = input.DateTo,
                Vehicle = input.Vehicle
            };
            
            return await listingRepo.AddAsync(listing);

        }
    }
}