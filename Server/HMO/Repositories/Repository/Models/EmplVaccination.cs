using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Repositories.Repository.Models;

[Keyless]
[Table("EmplVaccination")]
public partial class EmplVaccination
{
    public int EmployeeId { get; set; }

    public int VaccinationId { get; set; }

    public int? VaccinationNum { get; set; }

    [Column(TypeName = "date")]
    public DateTime? Date { get; set; }

    public int EmplVaccinationId { get; set; }
}
