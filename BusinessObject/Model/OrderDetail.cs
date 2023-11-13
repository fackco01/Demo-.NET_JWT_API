using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BusinessObject.Model
{
    public class OrderDetail
    {
        [Key]
        public int OrderId { get; set; }
        [Required] public int ProductId { get; set; }
        [Required] public int UnitPrice { get; set; }
        [Required] public int Quantity { get; set; }
        [Required] public int Discount { get; set; }

        [JsonIgnore]
        public virtual ICollection<Product>? Products { get; set; }
        [JsonIgnore]
        public virtual ICollection<Order>? Orders { get; set; }
    }
}
