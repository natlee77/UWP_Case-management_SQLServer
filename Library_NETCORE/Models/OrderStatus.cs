using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library_NETCORE.Models
{
    public partial class OrderStatus
    {
        public OrderStatus()
        {
            OrderProduct = new HashSet<OrderProduct>();
        }

        [Key]
        public int Id { get; set; }
        public int StatusDescript { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime OrderEditDate { get; set; }

        [ForeignKey(nameof(StatusDescript))]
        [InverseProperty("OrderStatus")]
        public virtual StatusDescript StatusDescriptNavigation { get; set; }
        [InverseProperty("OrderStatus")]
        public virtual ICollection<OrderProduct> OrderProduct { get; set; }
    }
}
