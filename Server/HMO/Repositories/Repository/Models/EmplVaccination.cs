using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Repositories.Repository.Models;

[Table("EmplVaccination")]
public partial class EmplVaccination
{
    [Key]
    public int EmplVaccinationId { get; set; }

    public long EmployeeId { get; set; }

    public int VaccinationId { get; set; }

    public int? VaccinationNum { get; set; }

    [Column(TypeName = "date")]
    public DateTime? Date { get; set; }

    [ForeignKey("EmployeeId")]
    [InverseProperty("EmplVaccinations")]
    public virtual Employee? Employee { get; set; } = null!;

    [ForeignKey("VaccinationId")]
    [InverseProperty("EmplVaccinations")]
    public virtual Vaccination? Vaccination { get; set; } = null!;
}
