using System;
using System.ComponentModel.DataAnnotations;

namespace Entity.ModelData
{
    public class Lease
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime LeasedFrom { get; set; }
        [Required]
        public DateTime LeasedTo { get; set; }
        public bool Canceled { get; set; }
        
        public Listing Listing { get; set; }
        
        public Customer Customer { get; set; }
    }
    
}