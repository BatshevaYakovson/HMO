using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Repositories.Repository.Models;

[Table("Disease")]
public partial class Disease
{
    [Key]
    public long EmployeeId { get; set; }

    [Column(TypeName = "date")]
    public DateTime? PositiveResult { get; set; }

    [Column(TypeName = "date")]
    public DateTime? Recovery { get; set; }

    [ForeignKey("EmployeeId")]
    [InverseProperty("Disease")]
    public virtual Employee? Employee { get; set; } = null!;
}
