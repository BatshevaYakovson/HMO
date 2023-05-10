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
    public long EmployeeId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? FullName { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Address { get; set; }

    [Column(TypeName = "date")]
    public DateTime? BornDate { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? Phone { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? CellPhone { get; set; }

    [InverseProperty("Employee")]
    public virtual Disease? Disease { get; set; }

    [InverseProperty("Employee")]
    public virtual ICollection<EmplVaccination> EmplVaccinations { get; set; } = new List<EmplVaccination>();
}
