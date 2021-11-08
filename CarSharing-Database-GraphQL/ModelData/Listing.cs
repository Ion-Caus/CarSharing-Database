using System;
using System.ComponentModel.DataAnnotations;

namespace CarSharing_Database_GraphQL.ModelData
{
    public class Listing
    {
        [Key]
        public int Id { get; set; }
        public DateTime ListedDate { get; set; }
        [Range(1, int.MaxValue)]
        public decimal Price { get; set; }
        [MaxLength(250)]
        public string Location { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public Vehicle Vehicle { get; set; }
        
    }
}