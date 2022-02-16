using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace northwind
{
    [Keyless]
    public class EmployeeTerritory
    {
        [Column("EmployeeID", TypeName = "int")]
        public long EmployeeId { get; set; }

        [Required]
        [Column("TerritoryID", TypeName = "nvarchar")]
        public string TerritoryId { get; set; }
    }
}