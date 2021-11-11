using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CarSharing_Database_GraphQL.ModelData;
using Microsoft.VisualBasic;

namespace CarSharing_Database_GraphQL.Repositories
{
    public interface IListingRepo
    {
        Task<Listing> AddAsync(Listing listing);
        Task<IList<Listing>> GetAsync(string location, DateTime dateFrom, DateTime dateTo);
        Task<Listing> GetAsync(string location, DateInterval dateInterval);
        Task<Listing> UpdateAsync(Listing listing);
        Task RemoveAsync(int id);
    }
}