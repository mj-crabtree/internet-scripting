using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace northwind
{
    [Keyless]
    public class Territory
    {
        [Required]
        [Column(TypeName = "nvarchar")]
        public string TerritoryID { get; set; }

        [Required]
        [Column(TypeName = "nchar")]
        public string TerritoryDescription { get; set; }

        [Column("RegionID", TypeName = "int")] public long RegionId { get; set; }
    }
}