using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarSharing_Database_GraphQL.ModelData;
using CarSharing_Database_GraphQL.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace CarSharing_Database_GraphQL.Repositories
{
    public class ListingRepo : IListingRepo
    {
        private readonly CarSharingDbContext _dbContext;

        public ListingRepo(CarSharingDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Listing> AddAsync(Listing listing)
        {
            var added = await _dbContext.Listings.AddAsync(listing);
            _dbContext.Attach(listing.Vehicle);
            await _dbContext.SaveChangesAsync();
            return added.Entity;
        }

        public async Task<IList<Listing>> GetAsync(string location, DateTime dateFrom, DateTime dateTo)
        {
            return await _dbContext.Listings
                .Include(listing =>  listing.Vehicle)
                .Where(l =>
                    l.Location.Equals(location)
                    && l.DateFrom < dateFrom
                    && l.DateTo > dateTo)
                .ToListAsync();
        }

        public Task<Listing> GetAsync(string location, DateInterval dateInterval)
        {
            throw new NotImplementedException();
        }

        public async Task<Listing> UpdateAsync(Listing listing)
        {
            try
            {
                // Listing toUpdate = await _dbContext.Listings.FirstAsync(l => l.Id == listing.Id);
                _dbContext.Update(listing);
                await _dbContext.SaveChangesAsync();
                return listing;
            }
            catch (Exception)
            {
                throw new Exception($"Did not find listing with id #{listing.Id}");
            }
        }


        public async Task RemoveAsync(int id)
        {
            Listing toRemove = await _dbContext.Listings.FirstOrDefaultAsync(l => l.Id == id);
            if (toRemove != null)
            {
                _dbContext.Listings.Remove(toRemove);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}