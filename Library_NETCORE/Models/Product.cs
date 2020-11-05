using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library_NETCORE.Models
{
    public partial class Product
    {
        public Product()
        {
            OrderProduct = new HashSet<OrderProduct>();
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

        [InverseProperty("Product")]
        public virtual ICollection<OrderProduct> OrderProduct { get; set; }
    }
}
