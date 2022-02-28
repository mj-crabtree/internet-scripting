using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Entities
{
    public partial class Student
    {
        [Key]
        public long StudentId { get; set; }
        [Column(TypeName = "STRING")]
        public string Firstname { get; set; }
        [Column(TypeName = "STRING")]
        public string Lastname { get; set; }
        public long? ExamMark { get; set; }
    }
}
