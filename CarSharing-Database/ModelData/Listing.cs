using System;

namespace CarSharing_Database.ModelData
{
    public class Listing
    {
        public DateTime ListedDate { get; set; }
        public decimal Price { get; set; }
        public string Location { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        
        //TODO 24.10 by Ion - if change to Vehicle then use Newtonsoft.Json
        public Vehicle Vehicle { get; set; }
        
    }
}