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
    public int EmployeeId { get; set; }

    [Column(TypeName = "date")]
    public DateTime? PositiveResult { get; set; }

    [Column(TypeName = "date")]
    public DateTime? Recovery { get; set; }

    [InverseProperty("EmployeeNavigation")]
    public virtual Employee? Employee { get; set; }
}
