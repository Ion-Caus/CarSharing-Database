using System.ComponentModel.DataAnnotations;

namespace Entity.ModelData
{
    public class Coupon
    {
        [Key]
        public string Code { get; set; }
        public double Discount { get; set; }
    }
}