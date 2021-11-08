using System;
using System.Collections.Generic;
using CarSharing_Database_GraphQL.ModelData;
using Microsoft.VisualBasic;

namespace CarSharing_Database_GraphQL.Repositories
{
    public interface IListingRepo
    {
        Listing Add(Listing listing);
        IList<Listing> Get(string location, DateTime dateFrom, DateTime dateTo);
        Listing Get(string location, DateInterval dateInterval);
        bool Update(Listing listing);
        bool Remove(int id);
    }
}