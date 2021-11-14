using System;
using CarSharing_Database_GraphQL.ModelData;

namespace CarSharing_Database_GraphQL.Mutations.Records
{
    public record UpdateListingInput(
        int Id,
        DateTime ListedDate,
        decimal Price,
        string Location,
        DateTime DateFrom,
        DateTime DateTo,
        Vehicle Vehicle
    );
}