using System;

namespace CarSharing_Database_GraphQL.Mutations.Records.LeaseRecords
{
    public record UpdateLeaseInput(
        int Id,
        DateTime LeasedFrom,
        DateTime LeasedTo,
        bool IsCanceled,
        ListingKey Listing,
        CustomerKey Customer
    );
}