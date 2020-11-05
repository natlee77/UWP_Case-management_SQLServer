using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace LibraryCore.Models
{
    [Table("StatusDescript")]
    public partial class StatusDescript
    {
        public StatusDescript()
        {
            OrderStatuses = new HashSet<OrderStatus>();
        }

        [Key]
        public int Id { get; set; }
        public bool Waiting { get; set; }
        public bool Active { get; set; }
        public bool Completed { get; set; }

        [InverseProperty(nameof(OrderStatus.StatusDescriptNavigation))]
        public virtual ICollection<OrderStatus> OrderStatuses { get; set; }
    }
}
