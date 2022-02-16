using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Sqlite.Migrations.Internal;

#nullable disable

namespace exercises
{
    public class Shipper
    {
        [Key] [Column("ShipperID")] public long ShipperId { get; set; }

        [Required]
        [Column(TypeName = "nvarchar (40)")]
        public string CompanyName { get; set; }

        [Column(TypeName = "nvarchar (24)")] public string Phone { get; set; }

        public static Shipper NewShipper(long id, string name, string phone)
        {
            var shipper = new Shipper();
            shipper.Phone = phone;
            shipper.CompanyName = name;
            shipper.ShipperId = id;
            return shipper;
        }
    }
}