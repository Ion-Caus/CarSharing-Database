using CarSharing_Database_GraphQL.ModelData;
using HotChocolate.Types;

namespace CarSharing_Database_GraphQL.GraphQLTypes
{
    public sealed class ListingType : ObjectType<Listing>
    {
        public ListingType()
        {
            Name = nameof(Listing);
            Description = "A movie in the collection";

            // Fiel(m => m.Id).Description("Identifier of the movie");
            // Field(m => m.Name).Description("Name of the movie");
            // Field(
            //     name: "Reviews",
            //     description: "Reviews of the movie",
            //     type: typeof(ListGraphType<ReviewObject>),
            //     resolve: m => m.Source.Reviews);
        }
    }
}