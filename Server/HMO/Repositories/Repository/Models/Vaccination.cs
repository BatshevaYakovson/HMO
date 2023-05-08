using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Repositories.Repository.Models;

[Table("Vaccination")]
public partial class Vaccination
{
    [Key]
    public int VaccinationId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Manufacturer { get; set; }
}
