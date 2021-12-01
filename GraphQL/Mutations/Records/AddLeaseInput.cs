using System;

namespace CarSharing_Database_GraphQL.Mutations.Records
{
    public record AddLeaseInput(
        DateTime LeasedFrom,
        DateTime LeasedTo,
        ListingId Listing,
        CustomerCpr Customer
    );

    public record ListingId(int Id);
    
    public record CustomerCpr(string Cpr);
}