using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library_NETCORE.Models
{
    public partial class Person
    {
        public Person()
        {
            Order = new HashSet<Order>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(50)]
        public string LastName { get; set; }
        [Required]
        [StringLength(100)]
        public string Adress { get; set; }
        [Required]
        [StringLength(100)]
        public string City { get; set; }
        public int PostCode { get; set; }

        [InverseProperty("Customer")]
        public virtual ICollection<Order> Order { get; set; }
    }
}
