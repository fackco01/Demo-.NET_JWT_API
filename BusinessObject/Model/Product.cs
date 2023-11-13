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
    public class Product
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductId { get; set; }
        [Required] public int CategoryId { get; set;}
        [Required] public string ProductName { get; set; }
        [Required] public float Weight { get; set; }
        [Required] public int UnitPrice { get; set; }
        [Required] public decimal UnitStock { get;set; }

        [JsonIgnore] 
        public virtual Category? Category { get; set; }
        [JsonIgnore]
        public virtual OrderDetail? OrderDetail { get; set; }
    }
}
