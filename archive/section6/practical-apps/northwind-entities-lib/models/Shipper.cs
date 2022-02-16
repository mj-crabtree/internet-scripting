using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Matt.Shared
{
    public class Shipper
    {
        public Shipper()
        {
            Orders = new HashSet<Order>();
        }

        [Key] public long ShipperID { get; set; }

        [Required]
        [Column(TypeName = "nvarchar (40)")]
        [StringLength(40)]
        public string CompanyName { get; set; }

        [Column(TypeName = "nvarchar (24)")]
        [StringLength(24)]
        public string Phone { get; set; }

        [InverseProperty(nameof(Order.ShipViaNavigation))]
        public virtual ICollection<Order> Orders { get; set; }
    }
}