using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Crabtree.Shared
{
    [Keyless]
    public partial class EmployeeTerritory
    {
        [Column("EmployeeID", TypeName = "int")]
        public long EmployeeID { get; set; }
        [Required]
        [Column("TerritoryID", TypeName = "nvarchar")]
        public string TerritoryID { get; set; }
    }
}
