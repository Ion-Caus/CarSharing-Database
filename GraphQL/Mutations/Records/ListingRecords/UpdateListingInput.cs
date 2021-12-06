using System;

namespace CarSharing_Database_GraphQL.Mutations.Records.ListingRecords
{
    public record UpdateListingInput(
        int Id,
        DateTime ListedDate,
        decimal Price,
        string Location,
        DateTime DateFrom,
        DateTime DateTo,
        VehicleKey Vehicle
    );
}