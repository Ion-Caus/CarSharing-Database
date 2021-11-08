using System;
using System.Collections.Generic;
using System.Linq;
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

        public Listing Add(Listing listing)
        {
            throw new NotImplementedException();
        }

        public IList<Listing> Get(string location, DateTime dateFrom, DateTime dateTo)
        {
            return _dbContext.Listings
                .Include(listing =>  listing.Vehicle)
                .Where(l =>
                    l.Location.Equals(location)
                    && l.DateFrom < dateFrom
                    && l.DateTo > dateTo)
                .ToList();
        }

        public Listing Get(string location, DateInterval dateInterval)
        {
            throw new NotImplementedException();
        }

        public bool Update(Listing listing)
        {
            throw new NotImplementedException();
        }

        public bool Remove(int id)
        {
            throw new NotImplementedException();
        }
    }
}