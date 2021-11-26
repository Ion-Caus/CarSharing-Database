using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HotChocolate;

namespace Entity.ModelData
{
    public class Listing : ISoftDeletable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime ListedDate { get; set; }
        [Range(1, int.MaxValue)]
        public decimal Price { get; set; }
        [MaxLength(250)]
        public string Location { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public Vehicle Vehicle { get; set; }

        [GraphQLIgnore]
        public bool IsDeleted { get; set; }
    }
}