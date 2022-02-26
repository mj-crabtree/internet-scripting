using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Crabtree.Shared
{
    [Keyless]
    public partial class Territory
    {
        [Required]
        public string TerritoryID { get; set; }
        [Required]
        [Column(TypeName = "nchar")]
        public string TerritoryDescription { get; set; }
        [Column("RegionID", TypeName = "int")]
        public long RegionID { get; set; }
    }
}
