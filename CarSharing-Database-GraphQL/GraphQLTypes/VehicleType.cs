using CarSharing_Database_GraphQL.ModelData;
using HotChocolate.Types;

namespace CarSharing_Database_GraphQL.GraphQLTypes
{
    //TODO 29.10 by Ion -- Create Type for all the model classe
    // research Resolver
    //or easy way - just add [GraphQLDescription("The type of the car")] to the model classes
    public sealed class VehicleType : ObjectType<Vehicle>
    {
        protected override void Configure(IObjectTypeDescriptor<Vehicle> descriptor)
        {
            descriptor.Description("Represents any car that can be rented or leased");

            descriptor
                .Field(p => p.Brand).Description("The brand of the car");
        }
    }
}