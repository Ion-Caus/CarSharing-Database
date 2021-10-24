using System;
using CarSharing_Database.ModelData;
using Microsoft.VisualBasic;

namespace CarSharing_Database.Dao
{
    public interface IListingDao
    {
        Listing Create(Listing listing);
        Listing Read(string location, DateTime dateFrom, DateTime dateTo);
        Listing Read(string location, DateInterval dateInterval);
        bool Update(Listing listing);
        bool Delete(int id);
    }
}