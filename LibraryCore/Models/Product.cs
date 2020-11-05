using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace LibraryCore.Models
{
    [Table("Product")]
    public partial class Product
    {
        public Product()
        {
            OrderProducts = new HashSet<OrderProduct>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Column(TypeName = "money")]
        public decimal Price { get; set; }

        [InverseProperty(nameof(OrderProduct.Product))]
        public virtual ICollection<OrderProduct> OrderProducts { get; set; }
    }
}
