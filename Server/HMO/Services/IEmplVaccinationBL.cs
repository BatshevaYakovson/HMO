using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repositories.Repository;
using Repositories.Repository.Models;

namespace Services
{
    public interface IEmplVaccinationBL
    {
        bool Create(EmplVaccination emplVaccinationToAdd);
        List<EmplVaccination> GetEmplVaccinations(int? id = 0);
    }
}
