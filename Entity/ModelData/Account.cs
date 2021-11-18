using System.ComponentModel.DataAnnotations;
using HotChocolate;

namespace Entity.ModelData
{
    public class Account
    {
        [Key]
        public string Username { get; set; }
        [Required]
        [GraphQLIgnore]
        public string Password { get; set; }
        public Customer Customer { get; set; }
    }
}