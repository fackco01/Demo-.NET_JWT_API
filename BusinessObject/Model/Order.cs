using Microsoft.AspNetCore.Identity;
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
    public class Order
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderId { get; set; }
        [Required] public int MemberId { get; set;}
        [Required] public DateTime OrderDate { get; set;}
        [Required] public DateTime RequiredDate { get; set;}
        [Required] public DateTime ShippedDate { get; set;}
        [Required] public string Freight { get; set;}

        [JsonIgnore]
        public virtual ICollection<OrderDetail>? Details { get; set;}
        [JsonIgnore]
        public virtual IdentityUser? AspNetUser { get; set; }
    }
}
