using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Repositories.Repository.Models;

[Table("Employee")]
public partial class Employee
{
    [Key]
    public int EmployeeId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? FullName { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Address { get; set; }

    [Column(TypeName = "date")]
    public DateTime? BornDate { get; set; }

    public int? Phone { get; set; }

    public int? CellPhone { get; set; }

    [ForeignKey("EmployeeId")]
    [InverseProperty("Employee")]
    public virtual Disease EmployeeNavigation { get; set; } = null!;
}
