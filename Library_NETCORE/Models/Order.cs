using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library_NETCORE.Models
{
    public partial class Order
    {
        public Order()
        {
            OrderProduct = new HashSet<OrderProduct>();
        }

        [Key]
        public int Id { get; set; }
        public int CustomerId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime OrderDate { get; set; }

        [ForeignKey(nameof(CustomerId))]
        [InverseProperty(nameof(Person.Order))]
        public virtual Person Customer { get; set; }
        [InverseProperty("Order")]
        public virtual ICollection<OrderProduct> OrderProduct { get; set; }
    }
}
