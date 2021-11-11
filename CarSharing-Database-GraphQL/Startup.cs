using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarSharing_Database_GraphQL.Mutations;
using CarSharing_Database_GraphQL.Repositories;
using CarSharing_Database_GraphQL.Persistence;
using CarSharing_Database_GraphQL.Queries;
using GraphQL.Server.Ui.Voyager;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CarSharing_Database_GraphQL
{
    public class Startup
    {
        // TODO 10.11 by Ion - Delete after development
        // exposes the details of the graphQL exceptions
        private readonly IWebHostEnvironment _env;

        public Startup(IWebHostEnvironment env)
        {
            _env = env;
        }
        // ------
        
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddDbContext<CarSharingDbContext>();
            
            services
                .AddScoped<IVehicleRepo, VehicleRepo>()
                .AddScoped<IListingRepo, ListingRepo>();

            services
                .AddGraphQLServer()
                // TODO 10.11 by Ion - Delete after development
                .ModifyRequestOptions(opt => opt.IncludeExceptionDetails = _env.IsDevelopment())
                //---
                .AddQueryType<Query>()
                .AddMutationType<Mutation>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app
                .UseRouting()
                .UseEndpoints(endpoints =>
                {
                    endpoints.MapGraphQL();
                });

            app.UseGraphQLVoyager(new GraphQLVoyagerOptions()
            {
                GraphQLEndPoint = "/graphql",
                Path = "/graphql-voyager"
            });
        }
    }
}