using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace LibraryCore.Models
{
    [Table("Order")]
    public partial class Order
    {
        public Order()
        {
            OrderProducts = new HashSet<OrderProduct>();
        }

        [Key]
        public int Id { get; set; }
        public int CustomerId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime OrderDate { get; set; }

        [ForeignKey(nameof(CustomerId))]
        [InverseProperty(nameof(Person.Orders))]
        public virtual Person Customer { get; set; }
        [InverseProperty(nameof(OrderProduct.Order))]
        public virtual ICollection<OrderProduct> OrderProducts { get; set; }
    }
}
