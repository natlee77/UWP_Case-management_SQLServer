using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace LibraryCore.Models
{
    [Table("OrderStatus")]
    public partial class OrderStatus
    {
        public OrderStatus()
        {
            OrderProducts = new HashSet<OrderProduct>();
        }

        [Key]
        public int Id { get; set; }
        public int StatusDescript { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime OrderEditDate { get; set; }

        [ForeignKey(nameof(StatusDescript))]
        [InverseProperty("OrderStatuses")]
        public virtual StatusDescript StatusDescriptNavigation { get; set; }
        [InverseProperty(nameof(OrderProduct.OrderStatus))]
        public virtual ICollection<OrderProduct> OrderProducts { get; set; }
    }
}
