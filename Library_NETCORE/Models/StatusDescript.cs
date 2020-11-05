using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library_NETCORE.Models
{
    public partial class StatusDescript
    {
        public StatusDescript()
        {
            OrderStatus = new HashSet<OrderStatus>();
        }

        [Key]
        public int Id { get; set; }
        public bool Waiting { get; set; }
        public bool Active { get; set; }
        public bool Completed { get; set; }

        [InverseProperty("StatusDescriptNavigation")]
        public virtual ICollection<OrderStatus> OrderStatus { get; set; }
    }
}
