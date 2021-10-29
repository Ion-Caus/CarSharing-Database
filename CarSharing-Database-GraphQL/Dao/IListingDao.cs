using System;
using System.Collections.Generic;
using CarSharing_Database_GraphQL.ModelData;
using Microsoft.VisualBasic;

namespace CarSharing_Database_GraphQL.Dao
{
    public interface IListingDao
    {
        Listing Create(Listing listing);
        IList<Listing> Read(string location, DateTime dateFrom, DateTime dateTo);
        Listing Read(string location, DateInterval dateInterval);
        bool Update(Listing listing);
        bool Delete(int id);
    }
}